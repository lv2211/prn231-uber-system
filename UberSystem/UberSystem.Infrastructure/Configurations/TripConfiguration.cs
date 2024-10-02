using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasOne(t => t.Customer)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.CustomerId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Driver)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.DriverId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
