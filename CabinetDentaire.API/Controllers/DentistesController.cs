using AutoMapper;
using CabinetDentaire.API.Models.Dentistes;
using CabinetDentaire.Services;
using CabinetDentaire.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CabinetDentaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistesController : ControllerBase
    {
        private readonly IDentisteService _dentisteService;
        private readonly IMapper _mapper;
        public DentistesController(IDentisteService dentisteService, IMapper mapper)
        {
            _dentisteService = dentisteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDentistes()
        {
            try
            {
                var data = await _dentisteService.GetDentistes();
                var dentistes = _mapper.Map<IEnumerable<DentisteDetails>>(data);
                return Ok(dentistes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchDentistes(Guid id, DentisteForUpdate dentisteForUpdate)
        {
            try
            {
                var dentisteWorkTime = _mapper.Map<WorkCategory>(dentisteForUpdate);
                var exucte = await _dentisteService.UpdateTimeWorkDentiste(id, dentisteWorkTime);
                if (exucte <= 0)
                {
                    return NotFound();
                }
                return Ok("Work time has  upadated successfully !!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
