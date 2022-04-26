using CabinetDentaire.Services.AppointmentServices;
using CabinetDentaire.Services.CancellationServices;
using CabinetDentaire.Services.ConsultationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Services
{
    public static class ServiceCollectionsExtenstion
    {
        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            return services.AddTransient<IPatientService, PatientService>()
                .AddTransient<IDentisteService, DentisteService>()
                .AddTransient<IAppointmentService, AppointmentService>()
                .AddTransient<IConsultationService, ConsultationService>()
                .AddTransient<ICancellationService, CancellationService>()
                ;
              
        }

       
    }
}
