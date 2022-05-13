using AutoMapper;
using CabinetDentaire.API.Models.Appointments;
using CabinetDentaire.Services.AppointmentServices;
using CabinetDentaire.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            try
            {
                var data = await _appointmentService.GetAppointments();
                var appointments = _mapper.Map<IEnumerable<AppointmentDetails>>(data);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] CreateAppointment appointmentforCreation)
        {
            try
            {
                var appointment = _mapper.Map<Appointment>(appointmentforCreation);
                var app = await _appointmentService.AddAppointment(appointment);
                return Ok(app);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
