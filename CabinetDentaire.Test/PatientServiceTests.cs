
using CabinetDentaire.Postgresql;
using CabinetDentaire.Services;
using CabinetDentaire.Shared.Entities;
using Postgresql;
using System;
using System.Linq;
using Xunit;

namespace CabinetDentaire.Test
{
    public class PatientServiceTests : IClassFixture<DatabaseFixture>
    {
       private   DatabaseFixture _databaseFixture;   
        private  IPatientService _patientService;
      
        public PatientServiceTests(DatabaseFixture databaseFixture)
        {
             _databaseFixture = databaseFixture;
            _patientService = new PatientService(_databaseFixture._postgreSqlSerives);

        }
        [Fact]
        public  async void ShouldReturnAllPatients()
        {
            //arrange
            var patients = await  _patientService.GetPatients();

            //act 

            //assert
            Assert.NotEmpty(patients);
            Assert.True(patients.Count() > 1);
            
        }

        [Fact]
        public async void ShouldReturnPatientWithOurConsultation()
        {
            //arrange
            var patientId = new Guid("eb8ea57c-b017-4990-99c6-ea11bcbd7e64");

            var patient = await _patientService.GetPatient(patientId);

            //assert

            Assert.NotNull(patient);
            Assert.True(patient.Select(a => a.Consultations.Select(c => c.Appointment)).Count() > 0);
            Assert.True(patient.Select(a => a.Consultations).Count() > 0);

        }

        [Fact]
        public async void ShouldAddedPatient()
        {
            var patient = new Patient
            {
                Name ="TEST 1",
                Address ="Address Test1",
                Phone="06666666",
                Email="emailTest1@gmail.com",
                Grender="Male"
            };

            var sut = await _patientService.AddPatient(patient);

            Assert.NotNull(sut);
            Assert.True(sut == 1);
            
        }
    }
}