using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(c => c.User)
                .WithMany(u => u.Customers)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
