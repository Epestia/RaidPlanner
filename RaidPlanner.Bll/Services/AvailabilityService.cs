using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RaidPlanner.Bll.Mappers;
using Mapster;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace RaidPlanner.Bll.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<IEnumerable<AvailabilityModel>> GetAllAvailabilitiesAsync()
        {
            var availabilities = await _availabilityRepository.GetAllAvailabilitiesAsync();
            return availabilities.Select(a => a.Adapt<AvailabilityModel>());
        }

        public async Task<AvailabilityModel> GetAvailabilityByIdAsync(int id)
        {
            var availability = await _availabilityRepository.GetAvailabilityByIdAsync(id);
            return availability?.Adapt<AvailabilityModel>();
        }

        public async Task AddAvailabilityAsync(AvailabilityModel availabilityModel)
        {
            var availability = availabilityModel.Adapt<Availability>();
            await _availabilityRepository.AddAvailabilityAsync(availability);
        }

        public async Task UpdateAvailabilityAsync(AvailabilityModel availabilityModel)
        {
            var availability = availabilityModel.Adapt<Availability>();
            await _availabilityRepository.UpdateAvailabilityAsync(availability);
        }

        public async Task DeleteAvailabilityAsync(int id)
        {
            await _availabilityRepository.DeleteAvailabilityAsync(id);
        }

        // Correction de la méthode GetAvailabilitiesByUserIdAsync
        public async Task<List<AvailabilityModel>> GetAvailabilitiesByUserIdAsync(int userId)
        {
            var availabilities = await _availabilityRepository.GetByUserIdAsync(userId);
            return availabilities.Select(a => a.Adapt<AvailabilityModel>()).ToList();
        }
    }
}
