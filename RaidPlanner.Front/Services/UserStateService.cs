using RaidPlanner.Front.Models;

namespace RaidPlanner.Front.Services
{
    public class UserStateService
    {
        public UserDto? CurrentUser { get; private set; }

        public event Action? OnChange;

        public void SetUser(UserDto user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public int? GetUserId()
        {
            return CurrentUser?.Id; 
        }

        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
