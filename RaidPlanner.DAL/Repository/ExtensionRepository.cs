using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Data;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaidPlanner.DAL.Repository
{
    public class ExtensionRepository : IExtensionRepository
    {
        private readonly AppDbContext _context;

        public ExtensionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Extension>> GetAllExtensionsAsync()
        {
            return await _context.Extensions.ToListAsync();
        }

        public async Task<Extension> GetExtensionByIdAsync(int id)
        {
            return await _context.Extensions
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddExtensionAsync(Extension extension)
        {
            await _context.Extensions.AddAsync(extension);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExtensionAsync(Extension extension)
        {
            _context.Extensions.Update(extension);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExtensionAsync(int id)
        {
            var extension = await _context.Extensions.FindAsync(id);
            if (extension != null)
            {
                _context.Extensions.Remove(extension);
                await _context.SaveChangesAsync();
            }
        }
    }
}
