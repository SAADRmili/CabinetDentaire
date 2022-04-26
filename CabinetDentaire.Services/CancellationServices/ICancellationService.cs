using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Services.CancellationServices
{
    public interface ICancellationService
    {
        Task<IEnumerable<Cancellation>> GetCancellations();
        Task<int> AddCancellation(Cancellation cancellation);
    }
}
