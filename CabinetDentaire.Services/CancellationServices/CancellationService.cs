using CabinetDentaire.Postgresql;
using CabinetDentaire.Shared.Entities;
using Dapper;
namespace CabinetDentaire.Services.CancellationServices
{
    public class CancellationService : ICancellationService
    {
        private readonly IPostgreSqlServices _postgreSqlService;

        public CancellationService(IPostgreSqlServices postgreSqlService)
        {
            _postgreSqlService = postgreSqlService;
        }
        public async Task<int> AddCancellation(Cancellation cancellation)
        {

            var checkQuery = "select count(1) from appointments where id=@id";
            var parmsCheck = new DynamicParameters();
            parmsCheck.Add("id", cancellation.AppointmentId, System.Data.DbType.Guid);
            var exists =  await _postgreSqlService.ExecuteScalarAsync(checkQuery, parmsCheck);

            if(exists)
            {
                var query = "insert into cancellations (date,description,appointmentid) values (@date ,@description ,@appid)";

                var parms = new DynamicParameters();

                parms.Add("date", cancellation.Date, System.Data.DbType.Date);
                parms.Add("description", cancellation.Description, System.Data.DbType.String);
                parms.Add("appid", cancellation.AppointmentId, System.Data.DbType.Guid);

                var excute = await _postgreSqlService.ExecuteAsync(query, parms);
                if (excute == 1)
                {
                    var queryUpdate = "Update appointments set iscancelled = True where id = @id";
                    parms.Add("id", cancellation.AppointmentId, System.Data.DbType.Guid);
                    return await _postgreSqlService.ExecuteAsync(queryUpdate, parms);

                }
            }


           
            return 0;

        }

        public Task<IEnumerable<Cancellation>> GetCancellations()
        {
            var query = "select canc.*, a.*,d.*,p.*,cat.* from cancellations canc join  appointments a on canc.appointmentid = a.id  join  dentistes d ON d.id = a.dentisteid join patients p on p.id = a.patientid  join consultationcategories cat ON cat.id = a.consultationcategoryid";

            var cancellationDict = new Dictionary<Guid, Cancellation>();


            return _postgreSqlService.QueryMultiAsync<Cancellation, Appointment, Dentiste,Patient,ConsultationCategory,Cancellation >(query, (cancellation, appointment,dentiste,patient,cat) =>
            {

                if (!cancellationDict.TryGetValue(cancellation.Id, out var currentCancellation))
                {
                    currentCancellation = cancellation;
                    cancellationDict.Add(currentCancellation.Id, cancellation);
                }

                currentCancellation.Appointment = appointment;
                currentCancellation.Appointment.Patient = patient;
                currentCancellation.Appointment.Dentiste = dentiste;
                currentCancellation.Appointment.ConsultationCategory = cat;

                return currentCancellation;
            });
        }
    }
}
