using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaidSessionController : ControllerBase
    {
        private readonly IRaidSessionService _raidSessionService;

        public RaidSessionController(IRaidSessionService raidSessionService)
        {
            _raidSessionService = raidSessionService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaidSessionDto>>> GetRaidSessions()
        {
            var raidSessions = await _raidSessionService.GetAllRaidSessionsAsync();
            var raidSessionDtos = raidSessions.Adapt<IEnumerable<RaidSessionDto>>();
            return Ok(raidSessionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaidSessionDto>> GetRaidSession(int id)
        {
            var raidSession = await _raidSessionService.GetRaidSessionByIdAsync(id);

            if (raidSession == null)
            {
                return NotFound();
            }

            var raidSessionDto = raidSession.Adapt<RaidSessionDto>();
            return Ok(raidSessionDto);
        }


        [HttpPost]
        public async Task<ActionResult<RaidSessionDto>> PostRaidSession(RaidSessionDto raidSessionDto)
        {
            var raidSessionModel = raidSessionDto.Adapt<RaidSessionModel>();
            await _raidSessionService.AddRaidSessionAsync(raidSessionModel);

            return CreatedAtAction(nameof(GetRaidSession), new { id = raidSessionDto.Id }, raidSessionDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaidSession(int id, RaidSessionDto raidSessionDto)
        {
            if (id != raidSessionDto.Id)
            {
                return BadRequest();
            }

            var raidSessionModel = raidSessionDto.Adapt<RaidSessionModel>();
            await _raidSessionService.UpdateRaidSessionAsync(raidSessionModel);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaidSession(int id)
        {
            var raidSession = await _raidSessionService.GetRaidSessionByIdAsync(id);
            if (raidSession == null)
            {
                return NotFound();
            }

            await _raidSessionService.DeleteRaidSessionAsync(id);

            return NoContent();
        }
    }
}
