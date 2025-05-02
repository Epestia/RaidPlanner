using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RaidPlanner.Front.Models;

namespace RaidPlanner.Front.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateUserAsync(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7131/api/Users", user);
            return response.IsSuccessStatusCode;
        }
    }
}
