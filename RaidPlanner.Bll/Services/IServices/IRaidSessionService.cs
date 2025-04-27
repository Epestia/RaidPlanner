using RaidPlanner.Bll.ObjectModels;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IRaidSessionService
    {
        Task<IEnumerable<RaidSessionModel>> GetAllRaidSessionsAsync();
        Task<RaidSessionModel?> GetRaidSessionByIdAsync(int id);
        Task AddRaidSessionAsync(RaidSessionModel raidSessionModel);
        Task UpdateRaidSessionAsync(RaidSessionModel raidSessionModel);
        Task DeleteRaidSessionAsync(int id);
    }
}
