using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.Services
{
    public interface IDentisteService
    {
        Task<IEnumerable<Dentiste>> GetDentistes();

        Task<Dentiste> GetDentiste(Guid id);
        Task<int> UpdateTimeWorkDentiste(Guid id, WorkCategory workCategory);
    }
}
