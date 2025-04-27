using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services
{
    public class ExtensionService : IExtensionService
    {
        private readonly IExtensionRepository _extensionRepository;

        public ExtensionService(IExtensionRepository extensionRepository)
        {
            _extensionRepository = extensionRepository;
        }

        public async Task<IEnumerable<ExtensionModel>> GetAllExtensionsAsync()
        {
            var extensions = await _extensionRepository.GetAllExtensionsAsync();
            return extensions.Select(extension => new ExtensionModel
            {
                Id = extension.Id,
                Name = extension.Name,
                Description = extension.Description
            });
        }

        public async Task<ExtensionModel> GetExtensionByIdAsync(int id)
        {
            var extension = await _extensionRepository.GetExtensionByIdAsync(id);
            if (extension == null)
                return null;

            return new ExtensionModel
            {
                Id = extension.Id,
                Name = extension.Name,
                Description = extension.Description
            };
        }

        public async Task AddExtensionAsync(ExtensionModel extensionModel)
        {
            var extension = new Extension
            {
                Name = extensionModel.Name,
                Description = extensionModel.Description
            };
            await _extensionRepository.AddExtensionAsync(extension);
        }

        public async Task UpdateExtensionAsync(ExtensionModel extensionModel)
        {
            var extension = new Extension
            {
                Id = extensionModel.Id,
                Name = extensionModel.Name,
                Description = extensionModel.Description
            };
            await _extensionRepository.UpdateExtensionAsync(extension);
        }

        public async Task DeleteExtensionAsync(int id)
        {
            await _extensionRepository.DeleteExtensionAsync(id);
        }
    }
}
