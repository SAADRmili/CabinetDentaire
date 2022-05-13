namespace CabinetDentaire.Shared.Entities
{
    public class Cancellation
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        //ForeignKeys

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
