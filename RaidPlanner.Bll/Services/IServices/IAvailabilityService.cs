using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<AvailabilityModel>> GetAllAvailabilitiesAsync();
        Task<AvailabilityModel> GetAvailabilityByIdAsync(int id);
        Task AddAvailabilityAsync(AvailabilityModel availabilityModel);
        Task UpdateAvailabilityAsync(AvailabilityModel availabilityModel);
        Task DeleteAvailabilityAsync(int id);
        Task<List<AvailabilityModel>> GetAvailabilitiesByUserIdAsync(int userId);

    }
}
