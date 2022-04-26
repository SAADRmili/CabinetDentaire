using CabinetDentaire.Services.AppointmentServices;
using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CabinetDentaire.Test
{
    public class AppointmentServiceTests: IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _databaseFixture;
        private IAppointmentService _appointmentSerivce;

        public AppointmentServiceTests(DatabaseFixture databaseFixture)
        {
                _databaseFixture = databaseFixture;
               _appointmentSerivce = new AppointmentService(databaseFixture._postgreSqlSerives);
        }

        [Fact]
        public async void ShouldBeAddAppointment()
        {
            var appointment = new Appointment
            {
                Date = DateTime.Now,
                DentisteId = new Guid("9f2eb2fc-79bd-414f-a687-1b178c0375fb"),
                PatientId = new Guid("570e7dea-93c9-4d32-bb20-47a06208c5e4"),
                ConsultationCategoryId = new Guid("be36aabc-626b-4d0b-94b8-a4027d446405"),
                
            };

            var sut = await _appointmentSerivce.AddAppointment(appointment);

            Assert.NotNull(sut);
            Assert.True(sut == 1);
        }

      
    }
}
