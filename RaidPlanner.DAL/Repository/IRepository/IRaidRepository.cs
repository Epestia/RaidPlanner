using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IRaidRepository
    {
        Task<IEnumerable<Raid>> GetAllAsync();
        Task<Raid?> GetByIdAsync(int id);
        Task AddAsync(Raid raid);
        Task UpdateAsync(Raid raid);
        Task DeleteAsync(Raid raid);
    }
}
