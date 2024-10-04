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
                },
                new Driver()
                {
                    Id = 3,
                    Dob = new DateTime(2003, 1, 1),
                    CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary()),
                    Status = DriverStatus.Available,
                    LocationLatitude = 10.762622,
                    LocationLongitude = 106.660172,
                    UserId = new Guid("a98c5333-1139-4caf-bb96-86d03624d96e")
                },
                new Driver()
                {
                    Id = 4,
                    Dob = new DateTime(2003, 1, 2),
                    CreateAt = BitConverter.GetBytes(DateTime.Now.ToBinary()),
                    LocationLatitude = 10.849163,
                    LocationLongitude = 106.771997,
                    Status = DriverStatus.Available,
                    UserId = new Guid("f6287dae-0e5c-4c5d-8fcd-cfb1ed255380")
                }
            );
        }
    }
}
