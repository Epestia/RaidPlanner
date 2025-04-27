using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Api.Dto;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Bll.ObjectModels;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;

        public AvailabilityController(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailabilityDto>>> GetAll()
        {
            var availabilities = await _availabilityService.GetAllAvailabilitiesAsync();
            return Ok(availabilities.Adapt<List<AvailabilityDto>>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AvailabilityDto>> GetById(int id)
        {
            var availability = await _availabilityService.GetAvailabilityByIdAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            return Ok(availability.Adapt<AvailabilityDto>());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AvailabilityDto availabilityDto)
        {
            var availabilityModel = availabilityDto.Adapt<AvailabilityModel>();
            await _availabilityService.AddAvailabilityAsync(availabilityModel);
            return CreatedAtAction(nameof(GetById), new { id = availabilityModel.Id }, availabilityDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AvailabilityDto availabilityDto)
        {
            if (id != availabilityDto.Id)
            {
                return BadRequest();
            }

            var availabilityModel = availabilityDto.Adapt<AvailabilityModel>();
            await _availabilityService.UpdateAvailabilityAsync(availabilityModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _availabilityService.DeleteAvailabilityAsync(id);
            return NoContent();
        }
    }
}
