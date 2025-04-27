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
    public class ExtensionController : ControllerBase
    {
        private readonly IExtensionService _extensionService;

        public ExtensionController(IExtensionService extensionService)
        {
            _extensionService = extensionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtensionDto>>> GetAll()
        {
            var extensions = await _extensionService.GetAllExtensionsAsync();
            return Ok(extensions.Adapt<List<ExtensionDto>>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExtensionDto>> GetById(int id)
        {
            var extension = await _extensionService.GetExtensionByIdAsync(id);
            if (extension == null)
            {
                return NotFound();
            }
            return Ok(extension.Adapt<ExtensionDto>());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ExtensionDto extensionDto)
        {
            var extensionModel = extensionDto.Adapt<ExtensionModel>();
            await _extensionService.AddExtensionAsync(extensionModel);
            return CreatedAtAction(nameof(GetById), new { id = extensionModel.Id }, extensionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ExtensionDto extensionDto)
        {
            if (id != extensionDto.Id)
            {
                return BadRequest();
            }

            var extensionModel = extensionDto.Adapt<ExtensionModel>();
            await _extensionService.UpdateExtensionAsync(extensionModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _extensionService.DeleteExtensionAsync(id);
            return NoContent();
        }
    }
}
