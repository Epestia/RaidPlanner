using System.Net.Http.Json;
using RaidPlanner.Front.Models;

namespace RaidPlanner.Front.Services
{
    public class ExtensionService
    {
        private readonly HttpClient _http;

        public ExtensionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ExtensionDto>> GetExtensionsAsync()
        {
            return await _http.GetFromJsonAsync<List<ExtensionDto>>("https://localhost:7131/api/Extension")
                   ?? new List<ExtensionDto>();
        }
    }
}
