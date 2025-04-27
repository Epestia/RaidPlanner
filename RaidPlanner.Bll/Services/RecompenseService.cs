using RaidPlanner.DAL.Repository.IRepository;
using RaidPlanner.Bll.Services.IServices;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.Bll.Services
{
    public class RecompenseService : IRecompenseService
    {
        private readonly IRecompenseRepository _recompenseRepository;

        public RecompenseService(IRecompenseRepository recompenseRepository)
        {
            _recompenseRepository = recompenseRepository;
        }

        public async Task<IEnumerable<RecompenseModel>> GetAllRecompensesAsync()
        {
            var recompenses = await _recompenseRepository.GetAllAsync();
            return recompenses.Select(r => new RecompenseModel
            {
                Id = r.Id,
                Name = r.Name,
                RaidId = r.RaidId
            });
        }

        public async Task<RecompenseModel?> GetRecompenseByIdAsync(int id)
        {
            var recompense = await _recompenseRepository.GetByIdAsync(id);
            if (recompense == null) return null;

            return new RecompenseModel
            {
                Id = recompense.Id,
                Name = recompense.Name,
                RaidId = recompense.RaidId
            };
        }

        public async Task AddRecompenseAsync(RecompenseModel recompenseModel)
        {
            var recompense = new Recompense
            {
                Name = recompenseModel.Name,
                RaidId = recompenseModel.RaidId
            };
            await _recompenseRepository.AddAsync(recompense);
        }

        public async Task UpdateRecompenseAsync(RecompenseModel recompenseModel)
        {
            var recompense = new Recompense
            {
                Id = recompenseModel.Id,
                Name = recompenseModel.Name,
                RaidId = recompenseModel.RaidId
            };
            await _recompenseRepository.UpdateAsync(recompense);
        }

        public async Task DeleteRecompenseAsync(int id)
        {
            var recompense = await _recompenseRepository.GetByIdAsync(id);
            if (recompense != null)
            {
                await _recompenseRepository.DeleteAsync(recompense);
            }
        }
    }
}
