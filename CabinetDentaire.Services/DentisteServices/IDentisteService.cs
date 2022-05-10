using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.Services
{
    public interface IDentisteService
    {
        Task<IEnumerable<Dentiste>> GetDentistes();
        Task<int> UpdateTimeWorkDentiste(Guid id, WorkCategory workCategory);
    }
}
