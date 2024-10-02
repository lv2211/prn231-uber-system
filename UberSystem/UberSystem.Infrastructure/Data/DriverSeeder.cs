using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;

namespace UberSystem.Infrastructure.Data
{
    public static class DriverSeeder
    {
        public static void SeedDriverInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasData(
                new Driver()
                {
                    Id = 1,
                    Dob = new DateTime(1996, 10, 10),
                    CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary()),
                    Status = DriverStatus.Available,
                    UserId = new Guid("98388595-6f18-4518-acb1-0718fd336864"),
                }
            );
        }
    }
}
