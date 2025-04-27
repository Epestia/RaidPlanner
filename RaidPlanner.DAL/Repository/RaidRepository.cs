using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;

namespace RaidPlanner.DAL.Repository
{
    public class RaidRepository : IRaidRepository
    {
        private readonly AppDbContext _context;

        public RaidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Raid>> GetAllAsync()
        {
            return await _context.Raids.Include(r => r.Extension).ToListAsync();
        }

        public async Task<Raid?> GetByIdAsync(int id)
        {
            return await _context.Raids.Include(r => r.Extension)
                                       .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Raid raid)
        {
            await _context.Raids.AddAsync(raid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Raid raid)
        {
            _context.Raids.Update(raid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Raid raid)
        {
            _context.Raids.Remove(raid);
            await _context.SaveChangesAsync();
        }
    }
}
