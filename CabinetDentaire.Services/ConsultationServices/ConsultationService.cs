using CabinetDentaire.Postgresql;
using CabinetDentaire.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace CabinetDentaire.Services.ConsultationServices
{
    public class ConsultationService : IConsultationService
    {
        private readonly IPostgreSqlServices _postgreSqlServices;
        public ConsultationService(IPostgreSqlServices postgreSqlServices)
        {
            _postgreSqlServices = postgreSqlServices;
        }
        public async Task<int> AddConsultation(Consultation consultation)
        {

            //Check if Appointment not Cancelled 
            var checkQuery = "select count(1) from appointments where id=@id and iscancelled = false";
            var parmsCheck = new DynamicParameters();
            parmsCheck.Add("id", consultation.AppointementId, System.Data.DbType.Guid);

            var exists = await _postgreSqlServices.ExecuteScalarAsync(checkQuery, parmsCheck);

            if(exists == false)
            {
                return 0;
            }

            var query = "insert into consultations(date,description,appointmentid) values (@date,@desc ,@appId) ";

            var parms = new DynamicParameters();
            parms.Add("date", consultation.Date, System.Data.DbType.Date);
            parms.Add("desc",consultation.Description, System.Data.DbType.String);
            parms.Add("appId", consultation.AppointementId,System.Data.DbType.Guid);

            return await _postgreSqlServices.ExecuteAsync(query, parms);
        } 
    }
}
