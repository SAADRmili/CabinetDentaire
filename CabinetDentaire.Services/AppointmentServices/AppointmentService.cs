using CabinetDentaire.Postgresql;
using CabinetDentaire.Shared.Entities;
using Dapper;
namespace CabinetDentaire.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IPostgreSqlServices _postgreSqlServices;
        public AppointmentService(IPostgreSqlServices postgreSqlServices)
        {
            _postgreSqlServices = postgreSqlServices;
        }
        public async Task<int> AddAppointment(Appointment appointment)
        {
            var query = "insert into appointments (id,date,dentisteid , patientid , consultationcategoryid) values (@id,@date , @did,@pid,@ccid)";

            var parms = new DynamicParameters();

            if (appointment != null)
            {
                parms.Add("id", appointment.Id, System.Data.DbType.Guid);
                parms.Add("date", appointment.Date, System.Data.DbType.Date);
                parms.Add("did", appointment.DentisteId, System.Data.DbType.Guid);
                parms.Add("pid", appointment.PatientId, System.Data.DbType.Guid);
                parms.Add("ccid", appointment.ConsultationCategoryId, System.Data.DbType.Guid);

                return await _postgreSqlServices.ExecuteAsync(query, parms);
            }
            return 0;

        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var query = "select  a.*,d.*,p.*,cat.* from appointments a  join  dentistes d ON d.id = a.dentisteid join patients p on p.id = a.patientid  join consultationcategories cat ON cat.id = a.consultationcategoryid  order by a.date DESC";


            var appDict = new Dictionary<Guid, Appointment>();
            return await _postgreSqlServices.QueryMultiAsync<Appointment, Dentiste, Patient, ConsultationCategory, Appointment>(query, (appointment, dentiste, patient, cat) =>
                 {
                     if (!appDict.TryGetValue(appointment.Id, out var currentAppointment))
                     {
                         currentAppointment = appointment;
                         appDict.Add(currentAppointment.Id, currentAppointment);
                     }
                     appointment.ConsultationCategory = cat;
                     appointment.Dentiste = dentiste;
                     appointment.Patient = patient;

                     return currentAppointment;

                 });
        }
    }
}
