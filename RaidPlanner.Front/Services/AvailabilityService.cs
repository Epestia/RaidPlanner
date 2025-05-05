using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RaidPlanner.Front.Models;

namespace RaidPlanner.Front.Services
{
    public class AvailabilityService
    {
        private readonly HttpClient _httpClient;

        public AvailabilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> CreateAsync(AvailabilityDto availability)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/availability", availability);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        // Méthode pour récupérer les disponibilités par utilisateur et inclure la description de la session de raid
        public async Task<List<AvailabilityDto>> GetAvailabilityByUserIdAsync(int userId)
        {
            var availabilityList = await _httpClient.GetFromJsonAsync<List<AvailabilityDto>>($"https://localhost:7131/api/Availability/user/{userId}");

            if (availabilityList == null)
                return new List<AvailabilityDto>();

            // Ajouter les descriptions des sessions de raid pour chaque disponibilité
            foreach (var availability in availabilityList)
            {
                var raidSession = await _httpClient.GetFromJsonAsync<RaidSessionDto>($"https://localhost:7131/api/RaidSession/{availability.RaidSessionId}");
                if (raidSession != null)
                {
                    availability.RaidSessionDescription = raidSession.Description; // Remplacer l'ID par la description
                }
            }

            return availabilityList;
        }

        public async Task<List<AvailabilityDto>> GetAvailabilitiesByRaidSessionIdAsync(int raidSessionId)
        {
            return await _httpClient.GetFromJsonAsync<List<AvailabilityDto>>($"https://localhost:7131/api/Availability/session/{raidSessionId}");
        }
    }
}
