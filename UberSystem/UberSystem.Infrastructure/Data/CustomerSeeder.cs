using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Data
{
    public static class CustomerSeeder
    {
        public static void SeedCustomerInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    UserId = new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02"),
                    CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary())
                }
            );
        }
    }
}
