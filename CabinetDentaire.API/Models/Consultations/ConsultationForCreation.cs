namespace CabinetDentaire.API.Models.Consultations
{
    public class ConsultationForCreation
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid AppointementId { get; set; }
    }
}
