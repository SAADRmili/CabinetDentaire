using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.API.Models.Appointments
{
    public class AppointmentDetails
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsCancelled { get; set; }

        public string Dentiste { get; set; }

        public string Patient { get; set; }

        public ConsultationCategory ConsultationCategory { get; set; }
    }
}
