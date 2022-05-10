namespace CabinetDentaire.Shared.Entities
{
    public class Appointment
    {

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsCancelled { get; set; }


        //ForeignKeys
        //dentiste
        public Guid DentisteId { get; set; }
        public Dentiste Dentiste { get; set; }

        //patient
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        //type consultation
        public Guid ConsultationCategoryId { get; set; }
        public ConsultationCategory ConsultationCategory { get; set; }
    }
}
