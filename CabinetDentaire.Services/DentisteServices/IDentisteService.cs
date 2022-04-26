using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Services
{
    public interface IDentisteService
    {
        Task<IEnumerable<Dentiste>> GetDentistes();

        Task<int> UpdateTimeWorkDentiste(Guid id,WorkCategory workCategory);
    }
}
