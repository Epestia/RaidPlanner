using Mapster;
using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Api.Dto;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();

            if (roles == null || !roles.Any())
            {
                return NotFound();
            }

            var rolesDto = roles.Adapt<IEnumerable<RoleDto>>();
            return Ok(rolesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _roleService.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var roleDto = role.Adapt<RoleDto>();
            return Ok(roleDto);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> PostRole(RoleDto roleDto)
        {
            var roleModel = roleDto.Adapt<RoleModel>();
            await _roleService.AddAsync(roleModel);
            var createdRoleDto = roleModel.Adapt<RoleDto>();
            return CreatedAtAction(nameof(GetRole), new { id = createdRoleDto.Id }, createdRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleDto roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest("Les identifiants ne correspondent pas.");
            }

            var existingRole = await _roleService.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound("Rôle non trouvé.");
            }

            var roleModel = roleDto.Adapt<RoleModel>();
            await _roleService.UpdateAsync(roleModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var existingRole = await _roleService.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound("Rôle non trouvé.");
            }

            await _roleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
