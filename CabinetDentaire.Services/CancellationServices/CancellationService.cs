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
        /// <summary>
        /// /I was creating a function in postgresql for check if appointment ready cancelled or not available
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<int> AddCancellation(Cancellation cancellation)
        {
            var query = "select  f_cancellation_upsert(@id,@date,@descrip)";
            var parms = new DynamicParameters();
            parms.Add("id", cancellation.AppointmentId, System.Data.DbType.Guid);
            parms.Add("date", cancellation.Date, System.Data.DbType.Date);
            parms.Add("descrip", cancellation.Description, System.Data.DbType.String);

            return await _postgreSqlService.QueryFirstOrDefaultAsync<int>(query, parms);
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
