using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.Services.ConsultationServices
{
    public interface IConsultationService
    {
        Task<int> AddConsultation(Consultation consultation);
    }
}
