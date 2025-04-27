using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IExtensionService
    {
        Task<IEnumerable<ExtensionModel>> GetAllExtensionsAsync();
        Task<ExtensionModel> GetExtensionByIdAsync(int id);
        Task AddExtensionAsync(ExtensionModel extensionModel);
        Task UpdateExtensionAsync(ExtensionModel extensionModel);
        Task DeleteExtensionAsync(int id);
    }
}
