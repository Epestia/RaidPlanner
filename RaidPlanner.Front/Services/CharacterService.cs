using RaidPlanner.Front.Models;
using System.Net.Http.Json;

namespace RaidPlanner.Front.Services
{
    public class CharacterService
    {
        private readonly HttpClient _httpClient;

        // Injecte HttpClient via le constructeur
        public CharacterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Méthode pour créer un personnage
        public async Task<bool> CreateCharacterAsync(CharacterDto characterDto)
        {
            try
            {
                // Envoie la requête POST pour créer le personnage
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/Character", characterDto);

                // Vérifie si la requête a réussi (code 2xx)
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                // En cas d'exception (comme une perte de connexion)
                return false;
            }

            return false;
        }
        public async Task<CharacterDto?> GetCharacterForUserAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CharacterDto>($"https://localhost:7131/api/Character/user/{userId}");
            }
            catch
            {
                return null;
            }
        }


    }
}
