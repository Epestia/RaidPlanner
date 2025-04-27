using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;

namespace RaidPlanner.DAL.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs.Include(j => j.Characters).ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _context.Jobs.Include(j => j.Characters)
                                      .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}
