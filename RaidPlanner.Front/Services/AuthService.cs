using RaidPlanner.Front.Models;
using RaidPlanner.Front.Services;
using System.Net.Http.Json;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly UserStateService _userState;

    public AuthService(HttpClient httpClient, UserStateService userState)
    {
        _httpClient = httpClient;
        _userState = userState;
    }

    public async Task<bool> LoginAsync(AuthDto   loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginDto);

        if (response.IsSuccessStatusCode)
        {
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            _userState.SetUser(user);
            return true;
        }

        return false;
    }

    public void Logout()
    {
        _userState.Logout();
    }
}
