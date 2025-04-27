using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Mappers;  
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaidController : ControllerBase
    {
        private readonly IRaidService _raidService;

        public RaidController(IRaidService raidService)
        {
            _raidService = raidService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaidDto>>> GetRaids()
        {
            var raids = await _raidService.GetAllRaidsAsync();


            var raidDtos = raids.Select(raid => raid.Adapt<RaidDto>()).ToList();

            return Ok(raidDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RaidDto>> GetRaid(int id)
        {
            var raid = await _raidService.GetRaidByIdAsync(id);

            if (raid == null)
            {
                return NotFound();
            }


            var raidDto = raid.Adapt<RaidDto>();

            return Ok(raidDto);
        }


        [HttpPost]
        public async Task<ActionResult<RaidDto>> PostRaid(RaidDto raidDto)
        {
 
            var raidModel = raidDto.Adapt<RaidModel>();

            await _raidService.AddRaidAsync(raidModel);

            return CreatedAtAction(nameof(GetRaid), new { id = raidDto.Id }, raidDto);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaid(int id, RaidDto raidDto)
        {
            if (id != raidDto.Id)
            {
                return BadRequest();
            }


            var raidModel = raidDto.Adapt<RaidModel>();

            await _raidService.UpdateRaidAsync(raidModel);

            return NoContent();  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaid(int id)
        {
            var raid = await _raidService.GetRaidByIdAsync(id);
            if (raid == null)
            {
                return NotFound();
            }

            await _raidService.DeleteRaidAsync(id);

            return NoContent();  
        }
    }
}
