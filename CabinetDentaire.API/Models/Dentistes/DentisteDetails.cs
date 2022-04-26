using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.API.Models.Dentistes
{
    public class DentisteDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public WorkCategory WorkCategory { get; set; }
    }
}
