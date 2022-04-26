using AutoMapper;
using CabinetDentaire.API.Models.Consultations;
using CabinetDentaire.Services.ConsultationServices;
using CabinetDentaire.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {

        private readonly IConsultationService _consultationService;
        private readonly IMapper _mapper;
        public ConsultationController(IConsultationService consultationService, IMapper mapper)
        {
            _consultationService = consultationService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddConsultation([FromForm] ConsultationForCreation consultationForCreation)
        {
            try
            {
                var consultation = _mapper.Map<Consultation>(consultationForCreation);
                var excute = await _consultationService.AddConsultation(consultation);
                if (excute <= 0)
                {
                    return BadRequest("Something was wrong");
                }
                return Ok("Consultation has added successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
