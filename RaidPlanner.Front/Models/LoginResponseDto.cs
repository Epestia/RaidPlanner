namespace RaidPlanner.Front.Models
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }  // L'utilisateur authentifié
        public string AccessToken { get; set; }  // Le token d'accès
        public string RefreshToken { get; set; }  // Le token de rafraîchissement
    }
}
