using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(payment => payment.Trip)
                .WithMany(t => t.Payments)
                .HasForeignKey(payment => payment.TripId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
