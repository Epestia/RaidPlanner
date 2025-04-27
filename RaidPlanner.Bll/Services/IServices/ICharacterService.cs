using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface ICharacterService
    {
        Task<CharacterModel> CreateCharacterAsync(CharacterModel characterModel);
        Task<CharacterModel> GetCharacterByIdAsync(int id);
        Task<IEnumerable<CharacterModel>> GetAllCharactersAsync();
        Task<CharacterModel> UpdateCharacterAsync(CharacterModel characterModel);
        Task<bool> DeleteCharacterAsync(int id);
    }
}
