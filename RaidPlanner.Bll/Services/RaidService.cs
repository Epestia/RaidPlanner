using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using RaidPlanner.Bll.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services
{
    public class RaidService : IRaidService
    {
        private readonly IRaidRepository _raidRepository;

        public RaidService(IRaidRepository raidRepository)
        {
            _raidRepository = raidRepository;
        }

        public async Task<IEnumerable<RaidModel>> GetAllRaidsAsync()
        {
            var raids = await _raidRepository.GetAllAsync();
            return raids.Select(MapRaidToModel).ToList();
        }

        public async Task<RaidModel?> GetRaidByIdAsync(int id)
        {
            var raid = await _raidRepository.GetByIdAsync(id);
            return raid != null ? MapRaidToModel(raid) : null;
        }

        public async Task AddRaidAsync(RaidModel raidModel)
        {
            var raid = MapModelToRaid(raidModel);
            await _raidRepository.AddAsync(raid);
        }

        public async Task UpdateRaidAsync(RaidModel raidModel)
        {
            var raid = MapModelToRaid(raidModel);
            await _raidRepository.UpdateAsync(raid);
        }

        public async Task DeleteRaidAsync(int id)
        {
            var raid = await _raidRepository.GetByIdAsync(id);
            if (raid != null)
            {
                await _raidRepository.DeleteAsync(raid);
            }
        }

        private static RaidModel MapRaidToModel(Raid raid)
        {
            return new RaidModel
            {
                Id = raid.Id,
                Name = raid.Name,
                NumberOfBosses = raid.NumberOfBosses,
                MinLevel = raid.MinLevel,
                Difficulty = raid.Difficulty,
                ExtensionId = raid.ExtensionId
            };
        }

        private static Raid MapModelToRaid(RaidModel raidModel)
        {
            return new Raid
            {
                Id = raidModel.Id,
                Name = raidModel.Name,
                NumberOfBosses = raidModel.NumberOfBosses,
                MinLevel = raidModel.MinLevel,
                Difficulty = raidModel.Difficulty,
                ExtensionId = raidModel.ExtensionId
            };
        }
    }
}
