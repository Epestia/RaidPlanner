using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RaidPlanner.Front.Models;
using System.Collections.Generic;

namespace RaidPlanner.Front.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Méthode existante pour créer un utilisateur
        public async Task<bool> CreateUserAsync(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/Users", user);
            return response.IsSuccessStatusCode;
        }

        // Nouvelle méthode pour récupérer les utilisateurs inscrits à une session de raid
        public async Task<List<UserDto>> GetUsersForRaidSessionAsync(int raidSessionId)
        {
            // Récupérer les availabilities de cette session
            var availabilities = await _httpClient.GetFromJsonAsync<List<AvailabilityDto>>(
                $"https://localhost:7131/api/Availability/session/{raidSessionId}");

            if (availabilities == null)
                return new List<UserDto>();

            // Extraire tous les userIds
            var userIds = availabilities.Select(a => a.UserId).Distinct().ToList();

            var users = new List<UserDto>();
            foreach (var userId in userIds)
            {
                var user = await _httpClient.GetFromJsonAsync<UserDto>($"https://localhost:7131/api/Users/{userId}");
                if (user != null)
                    users.Add(user);
            }

            return users;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<UserDto>($"https://localhost:7131/api/Users/{userId}");
        }
        public async Task<List<UserDto>> GetUsersForRaidSessionFromAvailabilityAsync(int raidSessionId)
        {
            var availabilities = await _httpClient.GetFromJsonAsync<List<AvailabilityDto>>("https://localhost:7131/api/Availability");
            var userIds = availabilities
                .Where(a => a.RaidSessionId == raidSessionId && a.Status == "Dispo")
                .Select(a => a.UserId)
                .Distinct()
                .ToList();

            var users = new List<UserDto>();
            foreach (var id in userIds)
            {
                var user = await _httpClient.GetFromJsonAsync<UserDto>($"https://localhost:7131/api/User/{id}");
                if (user != null)
                {
                    users.Add(user);
                }
            }

            return users;
        }

    }
}
