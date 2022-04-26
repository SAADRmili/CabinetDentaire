using CabinetDentaire.Services.AppointmentServices;
using CabinetDentaire.Services.CancellationServices;
using CabinetDentaire.Shared.Entities;
using System;
using Xunit;

namespace CabinetDentaire.Test
{
    public class CancellationServiceTests : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _databaseFixture;
        private ICancellationService _cancellationService;
        private IAppointmentService _appointmentService;

        public CancellationServiceTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _cancellationService = new CancellationService(_databaseFixture._postgreSqlSerives);
            _appointmentService = new AppointmentService(_databaseFixture._postgreSqlSerives);
        }

        [Fact]
        public async void ShouldCancelAnAppointment()
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

            var cancellation = new Cancellation
            {
                AppointmentId = appointment.Id,
                Date = DateTime.Now,
                Description = "This Is Description"
            };
            var sut = await _cancellationService.AddCancellation(cancellation);

            Assert.NotNull(sut);
            Assert.True(sut == 1);
        }

        [Fact]
        public async void ShouldCancelInvalidAppointment()
        {
            var cancellation = new Cancellation
            {
                Date = DateTime.Now,
                Description = "TEST FOR DESCRIPTION ",
                AppointmentId = new Guid("b0140791-0d0c-4580-bb34-970bf59687b2")
            };

            var sut = await _cancellationService.AddCancellation(cancellation);


            Assert.True(sut == 0);
        }
    }
}
