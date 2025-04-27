using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IRecompenseRepository
    {
        Task<IEnumerable<Recompense>> GetAllAsync();
        Task<Recompense?> GetByIdAsync(int id);
        Task AddAsync(Recompense recompense);
        Task UpdateAsync(Recompense recompense);
        Task DeleteAsync(Recompense recompense);
    }
}
