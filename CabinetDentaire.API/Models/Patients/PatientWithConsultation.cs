using CabinetDentaire.API.Models.Consultations;

namespace CabinetDentaire.API.Models.Patients
{
    public class PatientWithConsultation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Grender { get; set; }

        public List<ConsultationDetails> Consultations { get; set; } = new List<ConsultationDetails>();

    }
}
