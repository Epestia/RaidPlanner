using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Configurations
{
    public class RecompenseConfiguration : IEntityTypeConfiguration<Recompense>
    {
        public void Configure(EntityTypeBuilder<Recompense> builder)
        {
            builder.ToTable("Recompenses");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(r => r.Raid)
                .WithMany() 
                .HasForeignKey(r => r.RaidId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
