using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
