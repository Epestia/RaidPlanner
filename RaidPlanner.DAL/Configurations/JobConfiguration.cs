using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(j => j.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(j => j.Characters)
                .WithOne(c => c.Job)
                .HasForeignKey(c => c.JobId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
