using Microsoft.JSInterop;
using RaidPlanner.Front.Models;
using RaidPlanner.Front.Services;
using System.Net.Http.Json;
using System.Text.Json;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly UserStateService _userState;
    private readonly IJSRuntime _jsRuntime;

    public AuthService(HttpClient httpClient, UserStateService userState, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _userState = userState;
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> LoginAsync(AuthDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginDto);

        if (response.IsSuccessStatusCode)
        {
            // Lire la réponse sous forme de flux en mémoire avant de la désérialiser
            var memoryStream = new MemoryStream();
            await response.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin); // Revenir au début du flux pour la lecture
            var loginResponse = await JsonSerializer.DeserializeAsync<LoginResponseDto>(memoryStream);

            if (loginResponse != null)
            {
                // Stocker les tokens dans localStorage
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "access_token", loginResponse.AccessToken);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "refresh_token", loginResponse.RefreshToken);

                // Mettre à jour l'état de l'utilisateur
                _userState.SetUser(loginResponse.User);

                return true;
            }
        }

        return false;
    }

    public void Logout()
    {
        _userState.Logout();

        // Supprimer les tokens du localStorage lors de la déconnexion
        _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "access_token");
        _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "refresh_token");
    }

    // Cette méthode permet de récupérer le token d'accès depuis le localStorage
    public async Task<string> GetAccessTokenAsync()
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "access_token");
    }

    // Cette méthode permet de récupérer le token de rafraîchissement depuis le localStorage
    public async Task<string> GetRefreshTokenAsync()
    {
        return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "refresh_token");
    }

    // Méthode pour vérifier si un utilisateur est connecté en vérifiant la présence du token
    public async Task<bool> IsAuthenticatedAsync()
    {
        var accessToken = await GetAccessTokenAsync();
        return !string.IsNullOrEmpty(accessToken);
    }
}
