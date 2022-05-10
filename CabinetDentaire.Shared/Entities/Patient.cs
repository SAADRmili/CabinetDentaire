namespace CabinetDentaire.Shared.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Grender { get; set; }

        //list of appointments 
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}
