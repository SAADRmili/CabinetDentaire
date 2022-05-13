namespace CabinetDentaire.API.Models.Cancellations
{
    public class CancelAppointment
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        //ForeignKeys
        public Guid AppointmentId { get; set; }
    }
}
