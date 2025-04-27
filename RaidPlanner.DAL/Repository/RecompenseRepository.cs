using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;

namespace RaidPlanner.DAL.Repository
{
    public class RecompenseRepository : IRecompenseRepository
    {
        private readonly AppDbContext _context;

        public RecompenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recompense>> GetAllAsync()
        {
            return await _context.Recompenses.ToListAsync();
        }

        public async Task<Recompense?> GetByIdAsync(int id)
        {
            return await _context.Recompenses.FindAsync(id);
        }

        public async Task AddAsync(Recompense recompense)
        {
            await _context.Recompenses.AddAsync(recompense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recompense recompense)
        {
            _context.Recompenses.Update(recompense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recompense recompense)
        {
            _context.Recompenses.Remove(recompense);
            await _context.SaveChangesAsync();
        }
    }
}
