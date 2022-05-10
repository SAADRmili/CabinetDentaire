namespace CabinetDentaire.Shared.Entities
{
    public class Consultation
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        //ForeignKeys

        public Guid AppointementId { get; set; }

        public Appointment Appointment { get; set; }
    }
}
