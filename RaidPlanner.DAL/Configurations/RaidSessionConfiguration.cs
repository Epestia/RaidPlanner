using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaidPlanner.DAL.Models;

namespace RaidPlanner.DAL.Configurations
{
    public class RaidSessionConfiguration : IEntityTypeConfiguration<RaidSession>
    {
        public void Configure(EntityTypeBuilder<RaidSession> builder)
        {
            builder.ToTable("RaidSessions");

            builder.HasKey(rs => rs.Id);

            builder.Property(rs => rs.StartTime)
                .IsRequired();

            builder.Property(rs => rs.EndTime)
                .IsRequired();

            builder.Property(rs => rs.Description)
                .HasMaxLength(1000);
        }
    }
}
