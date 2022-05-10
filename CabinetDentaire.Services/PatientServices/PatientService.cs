
using CabinetDentaire.Postgresql;
using CabinetDentaire.Shared.Entities;
using Dapper;

namespace CabinetDentaire.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPostgreSqlServices _postgreSqlServices;
        public PatientService(IPostgreSqlServices postgreSqlServices)
        {
            _postgreSqlServices = postgreSqlServices;
        }
        public Task<IEnumerable<Patient>> GetPatients()
        {
            var query = "select * from patients ";
            return _postgreSqlServices.QueryAsync<Patient>(query);
        }
        public async Task<IEnumerable<Patient>> GetPatient(Guid id)
        {
            var query = "SELECT p.*,c.*,a.* ,d.* ,cc.* from patients p join appointments a on p.id = a.patientid join consultations c on  a.id = c.appointmentid join dentistes d on d.id = a.dentisteid join consultationcategories cc on cc.id = a.consultationcategoryid where p.id = @id";

            var parms = new DynamicParameters();

            parms.Add("id", id, System.Data.DbType.Guid);

            var patientDict = new Dictionary<Guid, Patient>();

            var data = await _postgreSqlServices.QueryMultiAsync<Patient, Consultation, Appointment, Dentiste, ConsultationCategory, Patient>(query, (patient, consultation, appointement, deniste, catrgory) =>
              {
                  if (!patientDict.TryGetValue(patient.Id, out var currentPatient))
                  {
                      currentPatient = patient;
                      patientDict.Add(currentPatient.Id, currentPatient);
                  }
                  consultation.AppointementId = appointement.Id;
                  consultation.Appointment = appointement;
                  consultation.Appointment.ConsultationCategory = catrgory;
                  consultation.Appointment.Dentiste = deniste;

                  currentPatient.Consultations.Add(consultation);
                  return currentPatient;

              }, parms, "id");
            return data.ToList();
        }
        public Task<int> AddPatient(Patient patient)
        {
            var query = "Insert into  patients (name,address,email , phone,grender) values (@name, @address, @email,@phone ,@grender)";

            var parms = new DynamicParameters();
            parms.Add("name", patient.Name, System.Data.DbType.String);
            parms.Add("email", patient.Email, System.Data.DbType.String);
            parms.Add("address", patient.Address, System.Data.DbType.String);
            parms.Add("phone", patient.Phone, System.Data.DbType.String);
            parms.Add("grender", patient.Grender, System.Data.DbType.String);

            return _postgreSqlServices.ExecuteAsync(query, parms);
        }

    }
}
