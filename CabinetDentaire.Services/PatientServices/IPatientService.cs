using CabinetDentaire.Shared.Entities;


namespace CabinetDentaire.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Patient>> GetPatient(Guid id);
        Task<int> AddPatient(Patient patient);

    }
}
