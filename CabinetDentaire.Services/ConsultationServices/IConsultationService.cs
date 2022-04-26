using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Services.ConsultationServices
{
    public interface IConsultationService
    {

        Task<int> AddConsultation(Consultation consultation);
    }
}
