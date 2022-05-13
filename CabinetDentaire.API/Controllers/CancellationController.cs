using AutoMapper;
using CabinetDentaire.API.Models.Cancellations;
using CabinetDentaire.Services.CancellationServices;
using CabinetDentaire.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellationController : ControllerBase
    {
        private readonly ICancellationService _cancellationService;
        private readonly IMapper _mapper;

        public CancellationController(ICancellationService cancellationService, IMapper mapper)
        {
            _cancellationService = cancellationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentCancellation()
        {
            try
            {
                var data = await _cancellationService.GetCancellations();
                var cancellations = _mapper.Map<IEnumerable<CancellationDetails>>(data);
                return Ok(cancellations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCancelAppointment([FromBody] CancelAppointment cancellationForCreation)
        {
            try
            {
                var cancellation = _mapper.Map<Cancellation>(cancellationForCreation);
                var excute = await _cancellationService.AddCancellation(cancellation);
                if(excute <=0 )
                {
                    return BadRequest("THE APPOINTMENT A READY CANCELLED");
                }
                return Ok("Cancellation of This appointment has  added successfally !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
