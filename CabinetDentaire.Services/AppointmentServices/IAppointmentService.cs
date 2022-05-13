using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<int> AddAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointments();
    }
}
