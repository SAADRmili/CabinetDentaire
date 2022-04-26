using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Shared.Entities
{
    public class ConsultationCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
