using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.API.Models.Appointments
{
    public class AppointmentForDetailsConsultation
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        //ForeignKeys
        //dentiste
       
        public Dentiste dentiste { get; set; }

        //type consultation
      
        public ConsultationCategory ConsultationCategory { get; set; }
    }
}
