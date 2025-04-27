using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;

namespace RaidPlanner.DAL.Repository
{
    public class RaidSessionRepository : IRaidSessionRepository
    {
        private readonly AppDbContext _context;

        public RaidSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaidSession>> GetAllAsync()
        {
            return await _context.RaidSessions.ToListAsync();
        }

        public async Task<RaidSession?> GetByIdAsync(int id)
        {
            return await _context.RaidSessions.FindAsync(id);
        }

        public async Task AddAsync(RaidSession raidSession)
        {
            await _context.RaidSessions.AddAsync(raidSession);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RaidSession raidSession)
        {
            _context.RaidSessions.Update(raidSession);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RaidSession raidSession)
        {
            _context.RaidSessions.Remove(raidSession);
            await _context.SaveChangesAsync();
        }
    }
}
