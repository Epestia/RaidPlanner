using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllAsync();
        Task<RoleModel?> GetByIdAsync(int id);
        Task AddAsync(RoleModel roleModel);
        Task UpdateAsync(RoleModel roleModel);
        Task DeleteAsync(int id);
    }
}
