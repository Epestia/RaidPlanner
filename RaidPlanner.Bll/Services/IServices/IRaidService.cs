using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IRaidService
    {
        Task<IEnumerable<RaidModel>> GetAllRaidsAsync();
        Task<RaidModel?> GetRaidByIdAsync(int id);
        Task AddRaidAsync(RaidModel raidModel);
        Task UpdateRaidAsync(RaidModel raidModel);
        Task DeleteRaidAsync(int id);
    }
}
