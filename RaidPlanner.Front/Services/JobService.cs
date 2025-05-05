using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlanner.Front.Models;

namespace RaidPlanner.Front.Services
{
    public class JobService
    {
        private readonly HttpClient _httpClient;

        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JobDto>> GetAllJobsAsync()
        {
            try
            {
                var jobs = await _httpClient.GetFromJsonAsync<List<JobDto>>("api/job");
                return jobs ?? new List<JobDto>();
            }
            catch
            {
                return new List<JobDto>();
            }
        }
    }
}
