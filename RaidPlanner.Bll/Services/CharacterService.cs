using Mapster;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharacterModel> CreateCharacterAsync(CharacterModel characterModel)
        {
            var character = characterModel.Adapt<Character>();
            await _characterRepository.AddCharacterAsync(character);
            return character.Adapt<CharacterModel>();
        }

        public async Task<CharacterModel> GetCharacterByIdAsync(int id)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(id);
            return character == null ? null : character.Adapt<CharacterModel>();
        }

        public async Task<IEnumerable<CharacterModel>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllCharactersAsync();
            return characters.Adapt<IEnumerable<CharacterModel>>();
        }

        public async Task<CharacterModel> UpdateCharacterAsync(CharacterModel characterModel)
        {
            var character = characterModel.Adapt<Character>();
            await _characterRepository.UpdateCharacterAsync(character);
            return character.Adapt<CharacterModel>();
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            await _characterRepository.DeleteCharacterAsync(id);
            return true;
        }
    }
}
