using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Shared.Entities
{
    public class Dentiste
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

     
        //ForeignKey
        public Guid WorkCategoryId { get; set; }

        public WorkCategory WorkCategory { get; set; }
    }
}
