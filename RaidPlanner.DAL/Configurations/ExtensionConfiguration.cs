using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Configurations
{
    public class ExtensionConfiguration : IEntityTypeConfiguration<Extension>
    {
        public void Configure(EntityTypeBuilder<Extension> builder)
        {
            builder.ToTable("Extensions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);
        }
    }
}
