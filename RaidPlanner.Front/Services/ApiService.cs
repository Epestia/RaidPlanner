using Microsoft.JSInterop;

namespace RaidPlanner.Front.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;

        public ApiService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<HttpResponseMessage> GetProtectedDataAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "access_token");

            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException("No access token found");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetAsync("api/protected-data");
        }
    }

}
