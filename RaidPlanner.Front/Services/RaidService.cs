
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using RaidPlanner.Front.Models;

    namespace RaidPlanner.Front.Services
    {
        public class RaidService
        {
            private readonly HttpClient _httpClient;

            public RaidService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            // Méthode pour récupérer tous les raids
            public async Task<List<RaidDto>> GetRaidsAsync()
            {
                try
                {
                    return await _httpClient.GetFromJsonAsync<List<RaidDto>>("https://localhost:7131/api/Raid") ?? new List<RaidDto>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de chargement des raids : " + ex.Message);
                    return new List<RaidDto>();
                }
            }
        }
    }


