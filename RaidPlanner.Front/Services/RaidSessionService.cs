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

        public async Task<List<RaidSessionDto>> GetRaidSessionsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<RaidSessionDto>>("https://localhost:7131/api/RaidSession");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des sessions de raid : {ex.Message}");
                return new List<RaidSessionDto>();
            }
        }

        public async Task<List<RaidSessionDto>> GetRaidSessionsByUserIdAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<RaidSessionDto>>($"https://localhost:7131/api/RaidSession/user/{userId}")
                    ?? new List<RaidSessionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des sessions pour l'utilisateur {userId} : {ex.Message}");
                return new List<RaidSessionDto>();
            }
        }

        public async Task<bool> CreateRaidSessionAsync(RaidSessionDto raidSessionDto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/RaidSession", raidSessionDto);
            return response.IsSuccessStatusCode;
        }
    }
}
