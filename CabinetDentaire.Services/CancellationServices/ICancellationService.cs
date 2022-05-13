using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.Services.CancellationServices
{
    public interface ICancellationService
    {
        Task<IEnumerable<Cancellation>> GetCancellations();
        Task<int> AddCancellation(Cancellation cancellation);
    }
}
