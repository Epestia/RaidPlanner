using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.DAL.Repository
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly AppDbContext _context;

        public AvailabilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync()
        {
            return await _context.Availabilities
                .Include(a => a.User)
                .Include(a => a.RaidSession)
                .ToListAsync();
        }

        public async Task<Availability> GetAvailabilityByIdAsync(int id)
        {
            return await _context.Availabilities
                .Include(a => a.User)
                .Include(a => a.RaidSession)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAvailabilityAsync(Availability availability)
        {
            await _context.Availabilities.AddAsync(availability);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAvailabilityAsync(Availability availability)
        {
            _context.Availabilities.Update(availability);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAvailabilityAsync(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability != null)
            {
                _context.Availabilities.Remove(availability);
                await _context.SaveChangesAsync();
            }
        }
    }
}
