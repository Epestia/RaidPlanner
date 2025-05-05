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
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();

            if (characters == null || !characters.Any())
            {
                return NotFound();
            }

            var charactersDto = characters.Adapt<IEnumerable<CharacterDto>>();
            return Ok(charactersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            var characterDto = character.Adapt<CharacterDto>();
            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> PostCharacter(CharacterDto characterDto)
        {
            var characterModel = characterDto.Adapt<CharacterModel>();
            var createdCharacter = await _characterService.CreateCharacterAsync(characterModel);
            var createdCharacterDto = createdCharacter.Adapt<CharacterDto>();

            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacterDto.Id }, createdCharacterDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterDto characterDto)
        {
            if (id != characterDto.Id)
            {
                return BadRequest("Les identifiants ne correspondent pas.");
            }

            var existingCharacter = await _characterService.GetCharacterByIdAsync(id);
            if (existingCharacter == null)
            {
                return NotFound("Personnage non trouvé.");
            }

            var characterModel = characterDto.Adapt<CharacterModel>();

            await _characterService.UpdateCharacterAsync(characterModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var existingCharacter = await _characterService.GetCharacterByIdAsync(id);
            if (existingCharacter == null)
            {
                return NotFound("Personnage non trouvé.");
            }

            var success = await _characterService.DeleteCharacterAsync(id);
            if (!success)
            {
                return BadRequest("Échec de la suppression du personnage.");
            }

            return NoContent();
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CharacterModel>>> GetCharactersByUserId(int userId)
        {
            var characters = await _characterService.GetCharactersByUserIdAsync(userId);
            if (characters == null || !characters.Any())
                return NotFound();

            return Ok(characters);
        }


    }
}
