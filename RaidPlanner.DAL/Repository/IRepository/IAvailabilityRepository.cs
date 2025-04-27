using RaidPlanner.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.DAL.Repository.IRepository
{
    public interface IAvailabilityRepository
    {
        Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync();
        Task<Availability> GetAvailabilityByIdAsync(int id);
        Task AddAvailabilityAsync(Availability availability);
        Task UpdateAvailabilityAsync(Availability availability);
        Task DeleteAvailabilityAsync(int id);
    }
}
