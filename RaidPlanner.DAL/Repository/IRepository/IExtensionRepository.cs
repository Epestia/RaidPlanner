using RaidPlanner.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IExtensionRepository
    {
        Task<IEnumerable<Extension>> GetAllExtensionsAsync();
        Task<Extension> GetExtensionByIdAsync(int id);
        Task AddExtensionAsync(Extension extension);
        Task UpdateExtensionAsync(Extension extension);
        Task DeleteExtensionAsync(int id);
    }
}
