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
                    Type = "Hyundai Accent - Sedan",
                    RegNo = "51A-12345",
                },
                new Cab()
                {
                    Id = 2,
                    Type = "Toyota Camry - Sedan",
                    RegNo = "30B-67890"
                },
                new Cab()
                {
                    Id = 3,
                    Type = "Honda Civic - Sedan",
                    RegNo = "29C-54321"
                },
                new Cab()
                {
                    Id = 4,
                    Type = "Ford Fiesta - Hatchback",
                    RegNo = "50D-11223"
                },
                new Cab()
                {
                    Id = 5,
                    Type = "Kia Sorento - SUV",
                    RegNo = "60E-98765"
                },
                new Cab()
                {
                    Id = 6,
                    Type = "Chevrolet Cruze - Sedan",
                    RegNo = "45F-22334"
                },
                new Cab()
                {
                    Id = 7,
                    Type = "Mazda 3 - Sedan",
                    RegNo = "51G-99887"
                },
                new Cab()
                {
                    Id = 8,
                    Type = "Toyota Fortuner - SUV",
                    RegNo = "48H-45678"
                },
                new Cab()
                {
                    Id = 9,
                    Type = "Hyundai Elantra - Sedan",
                    RegNo = "55K-33445"
                },
                new Cab()
                {
                    Id = 10,
                    Type = "Mitsubishi Xpander - MPV",
                    RegNo = "61L-56789"
                }
            );
        }
    }
}
