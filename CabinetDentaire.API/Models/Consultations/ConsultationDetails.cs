using CabinetDentaire.API.Models.Appointments;
using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.API.Models.Consultations
{
    public class ConsultationDetails
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public AppointmentForDetailsConsultation Appointment { get; set; }
    }
}
