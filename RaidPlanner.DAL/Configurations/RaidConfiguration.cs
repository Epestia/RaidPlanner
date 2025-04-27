using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Configurations
{
    public class RaidConfiguration : IEntityTypeConfiguration<Raid>
    {
        public void Configure(EntityTypeBuilder<Raid> builder)
        {
            builder.ToTable("Raids");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.NumberOfBosses)
                .IsRequired();

            builder.Property(r => r.MinLevel)
                .IsRequired();

            builder.Property(r => r.Difficulty)
                .IsRequired();

            builder.HasOne(r => r.Extension) 
                .WithMany(e => e.Raids)      
                .HasForeignKey(r => r.ExtensionId)  
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
