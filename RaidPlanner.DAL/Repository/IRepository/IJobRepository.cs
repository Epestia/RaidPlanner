using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(int id);
        Task AddAsync(Job job);
        Task UpdateAsync(Job job);
        Task DeleteAsync(Job job);
    }
}
