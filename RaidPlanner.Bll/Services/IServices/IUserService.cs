using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> UpdateUserAsync(UserModel userModel);
        Task<bool> DeleteUserAsync(int userId);
    }
}
