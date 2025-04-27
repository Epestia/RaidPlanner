using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IRaidSessionRepository
    {
        Task<IEnumerable<RaidSession>> GetAllAsync();
        Task<RaidSession?> GetByIdAsync(int id);
        Task AddAsync(RaidSession raidSession);
        Task UpdateAsync(RaidSession raidSession);
        Task DeleteAsync(RaidSession raidSession);
    }
}
