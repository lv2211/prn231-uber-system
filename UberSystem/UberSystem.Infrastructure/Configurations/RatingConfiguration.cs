using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(r => r.Driver)
                .WithMany(d => d.Ratings)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Driver)
                .WithMany(d => d.Ratings)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.Driver)
                .WithMany(d => d.Ratings)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
