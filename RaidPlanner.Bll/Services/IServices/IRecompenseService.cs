using RaidPlanner.Bll.ObjectModels;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IRecompenseService
    {
        Task<IEnumerable<RecompenseModel>> GetAllRecompensesAsync();
        Task<RecompenseModel?> GetRecompenseByIdAsync(int id);
        Task AddRecompenseAsync(RecompenseModel recompense);
        Task UpdateRecompenseAsync(RecompenseModel recompense);
        Task DeleteRecompenseAsync(int id);
    }
}
