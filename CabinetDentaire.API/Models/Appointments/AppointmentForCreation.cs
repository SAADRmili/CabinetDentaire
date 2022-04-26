namespace CabinetDentaire.API.Models.Appointments
{
    public class AppointmentForCreation
    {

        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public Guid DentisteId { get; set; }
      
        //patient
        public Guid PatientId { get; set; }
     

        //type consultation
        public Guid ConsultationCategoryId { get; set; }
  
    }
}
