using RaidPlanner.Front.Models;
using System.Net.Http.Json;

namespace RaidPlanner.Front.Services
{
    public class RaidSessionService
    {
        private readonly HttpClient _httpClient;

        public RaidSessionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Méthode pour récupérer les sessions de raid
        public async Task<List<RaidSessionDto>> GetRaidSessionsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<RaidSessionDto>>("https://localhost:7131/api/RaidSession");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des sessions de raid : {ex.Message}");
                return new List<RaidSessionDto>(); // Retourner une liste vide en cas d'erreur
            }
        }

        public async Task<bool> CreateRaidSessionAsync(RaidSessionDto raidSessionDto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/RaidSession", raidSessionDto);

            return response.IsSuccessStatusCode;
        }
    }
}
