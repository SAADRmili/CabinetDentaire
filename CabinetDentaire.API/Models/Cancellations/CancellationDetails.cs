using CabinetDentaire.API.Models.Appointments;

namespace CabinetDentaire.API.Models.Cancellations
{
    public class CancellationDetails
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public AppointmentDetails Appointment { get; set; }
    }
}
