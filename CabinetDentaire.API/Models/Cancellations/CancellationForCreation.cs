namespace CabinetDentaire.API.Models.Cancellations
{
    public class CancellationForCreation
    {
      
        public DateTime Date { get; set; }

        public string Description { get; set; }

        //ForeignKeys

        public Guid AppointmentId { get; set; }
    }
}
