using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Api.Dtos;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecompenseController : ControllerBase
    {
        private readonly IRecompenseService _recompenseService;

        public RecompenseController(IRecompenseService recompenseService)
        {
            _recompenseService = recompenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecompenseDto>>> GetRecompenses()
        {
            var recompenses = await _recompenseService.GetAllRecompensesAsync();
            var result = recompenses.Select(r => new RecompenseDto
            {
                Id = r.Id,
                Name = r.Name,
                RaidId = r.RaidId
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecompenseDto>> GetRecompense(int id)
        {
            var recompense = await _recompenseService.GetRecompenseByIdAsync(id);
            if (recompense == null) return NotFound();

            var result = new RecompenseDto
            {
                Id = recompense.Id,
                Name = recompense.Name,
                RaidId = recompense.RaidId
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostRecompense(RecompenseDto recompenseDto)
        {
            var recompenseModel = new RecompenseModel
            {
                Name = recompenseDto.Name,
                RaidId = recompenseDto.RaidId
            };
            await _recompenseService.AddRecompenseAsync(recompenseModel);

            return CreatedAtAction(nameof(GetRecompense), new { id = recompenseDto.Id }, recompenseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecompense(int id, RecompenseDto recompenseDto)
        {
            if (id != recompenseDto.Id) return BadRequest();

            var recompenseModel = new RecompenseModel
            {
                Id = recompenseDto.Id,
                Name = recompenseDto.Name,
                RaidId = recompenseDto.RaidId
            };

            await _recompenseService.UpdateRecompenseAsync(recompenseModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecompense(int id)
        {
            var recompense = await _recompenseService.GetRecompenseByIdAsync(id);
            if (recompense == null) return NotFound();

            await _recompenseService.DeleteRecompenseAsync(id);

            return NoContent();
        }
    }
}
