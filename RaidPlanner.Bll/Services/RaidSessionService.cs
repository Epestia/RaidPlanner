using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using Mapster; 

namespace RaidPlanner.Bll.Services
{
    public class RaidSessionService : IRaidSessionService
    {
        private readonly IRaidSessionRepository _raidSessionRepository;

        public RaidSessionService(IRaidSessionRepository raidSessionRepository)
        {
            _raidSessionRepository = raidSessionRepository;
        }

        public async Task<IEnumerable<RaidSessionModel>> GetAllRaidSessionsAsync()
        {
            var raidSessions = await _raidSessionRepository.GetAllAsync();
            return raidSessions.Adapt<IEnumerable<RaidSessionModel>>();
        }

        public async Task<RaidSessionModel?> GetRaidSessionByIdAsync(int id)
        {
            var raidSession = await _raidSessionRepository.GetByIdAsync(id);
            return raidSession?.Adapt<RaidSessionModel>();
        }

        public async Task AddRaidSessionAsync(RaidSessionModel raidSessionModel)
        {
            var raidSession = raidSessionModel.Adapt<RaidSession>();
            await _raidSessionRepository.AddAsync(raidSession);
        }

        public async Task UpdateRaidSessionAsync(RaidSessionModel raidSessionModel)
        {
            var raidSession = raidSessionModel.Adapt<RaidSession>();
            await _raidSessionRepository.UpdateAsync(raidSession);
        }

        public async Task DeleteRaidSessionAsync(int id)
        {
            var raidSession = await _raidSessionRepository.GetByIdAsync(id);
            if (raidSession != null)
            {
                await _raidSessionRepository.DeleteAsync(raidSession);
            }
        }
    }
}
