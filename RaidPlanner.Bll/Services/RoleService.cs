using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using RaidPlanner.Bll.Mappers;
using RaidPlanner.Bll.Services.IServices;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            BllDalMappingConfig.ConfigureMappings();
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Adapt<IEnumerable<RoleModel>>();
        }

        public async Task<RoleModel?> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role?.Adapt<RoleModel>();
        }

        public async Task AddAsync(RoleModel roleModel)
        {
            var role = roleModel.Adapt<Role>();
            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(RoleModel roleModel)
        {
            var role = roleModel.Adapt<Role>();
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role != null)
            {
                await _roleRepository.DeleteAsync(role);
            }
        }
    }
}
