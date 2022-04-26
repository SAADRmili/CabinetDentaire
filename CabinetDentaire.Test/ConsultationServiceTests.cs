using CabinetDentaire.Services.AppointmentServices;
using CabinetDentaire.Services.ConsultationServices;
using CabinetDentaire.Shared.Entities;
using System;
using Xunit;

namespace CabinetDentaire.Test
{
    public class ConsultationServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private IConsultationService _consultationService;
        private IAppointmentService _appointmentService;
        public ConsultationServiceTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _consultationService = new ConsultationService(_databaseFixture._postgreSqlSerives);
            _appointmentService = new AppointmentService(_databaseFixture._postgreSqlSerives);
        }

        [Fact]
        public async void ShouldAddConsultation()
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                ConsultationCategoryId = new Guid("be36aabc-626b-4d0b-94b8-a4027d446405"),
                DentisteId = new Guid("ec13d7ed-b91e-4bc0-a872-27b9dec6b860"),
                Date = DateTime.Now,
                PatientId = new Guid("8c7e7df6-afc7-4ce1-ae1e-0d736fc5d133"),
            };

            var appSut = await _appointmentService.AddAppointment(appointment);

            var consultation = new Consultation
            {
                Date = DateTime.Now,
                Description = "Description Test1",
                AppointementId = appointment.Id,
            };

            var sut = await _consultationService.AddConsultation(consultation);

            Assert.NotNull(sut);
            Assert.True(sut == 1);
        }
        [Fact]
        public async void ShouldReturnFalseWhenAddConsultation()
        {
            var consultation = new Consultation
            {
                Date = DateTime.Now,
                Description = "Description Test1",
                AppointementId = new Guid("d2dd7666-9d62-45dd-ae70-e46570f0e96f"),
            };

            var sut = await _consultationService.AddConsultation(consultation);


            Assert.True(sut == 0);
        }
    }
}
