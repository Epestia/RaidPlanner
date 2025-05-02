using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            var role = await _roleRepository.GetByIdAsync(1);
            if (role != null)
            {
                var user = new User
                {
                    Username = userModel.Username,
                    Mail = userModel.Mail,
                    Password = userModel.Password,
                    RoleId = role.Id
                };

                await _userRepository.AddAsync(user);

                userModel.Id = user.Id;
                return userModel;
            }

            return null;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel userModel)
        {
            var user = await _userRepository.GetByIdAsync(userModel.Id);
            if (user == null)
            {
                return null;
            }

            user.Username = userModel.Username;
            user.Mail = userModel.Mail;
            user.Password = userModel.Password;

            await _userRepository.UpdateAsync(user);

            return userModel;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(user);

            return true;
        }

        public async Task<UserModel?> ValidateUser(string username, string password)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
                return null;

            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Mail = user.Mail
            };
        }

    }
}
