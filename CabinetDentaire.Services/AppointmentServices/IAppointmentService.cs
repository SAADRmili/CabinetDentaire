using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<int> AddAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointments();
    }
}
