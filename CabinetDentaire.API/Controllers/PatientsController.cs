
using AutoMapper;
using CabinetDentaire.API.Models.Patients;
using CabinetDentaire.Services;
using CabinetDentaire.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var data = await _patientService.GetPatients();
                var patients = _mapper.Map<IEnumerable<PatientDetails>>(data);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            try
            {
                var data = await _patientService.GetPatient(id);
                var patient = _mapper.Map<IEnumerable<PatientWithConsultation>>(data);
                return Ok(patient.First());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientForCreation patientForCreation)
        {
            try
            {
                var patient = _mapper.Map<Patient>(patientForCreation);
                var excute = await _patientService.AddPatient(patient);
                if (excute <= 0)
                {
                    return BadRequest("Something was wrong");
                }
                return Ok("Patient has added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
