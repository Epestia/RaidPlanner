using RaidPlanner.Front.Models;
using System.Net.Http.Json;

namespace RaidPlanner.Front.Services
{
    public class CharacterService
    {
        private readonly HttpClient _httpClient;

        public CharacterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateCharacterAsync(CharacterDto characterDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/Character", characterDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateCharacterAsync(CharacterDto character)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Character/{character.Id}", character);
            return response.IsSuccessStatusCode;
        }


        public async Task<IEnumerable<CharacterDto>> GetCharactersForUserAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CharacterDto>>(
                    $"https://localhost:7131/api/Character/user/{userId}"
                ) ?? new List<CharacterDto>();
            }
            catch
            {
                return new List<CharacterDto>();
            }
        }
        public async Task<CharacterDto?> GetCharacterByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Character/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CharacterDto>();
            }

            return null;
        }

    }
}
