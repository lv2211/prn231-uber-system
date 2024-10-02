using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Data
{
    public static class CabSeeder
    {
        public static void SeedCabInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cab>().HasData(
                new Cab()
                {
                    Id = 1,
                    DriverId = 1,
                    Type = "Hyundai Accent - Sedan",
                    RegNo = "51A-12345",
                }
            );
        }
    }
}
