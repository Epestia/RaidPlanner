using Microsoft.EntityFrameworkCore;
using RaidPlanner.DAL.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RaidPlanner.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Raid> Raids { get; set; }
        public DbSet<Recompense> Recompenses { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<RaidSession> RaidSessions { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
