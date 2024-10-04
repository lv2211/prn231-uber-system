using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;

namespace UberSystem.Infrastructure.Data
{
    public static class TripSeeder
    {
        public static void SeedDataForTrip(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    CustomerId = 1,
                    DriverId = 1,
                    Status = TripStatus.Completed,
                    SourceLatitude = 37.7749,
                    SourceLongitude = -122.4194,
                    DestinationLatitude = 34.0522,
                    DestinationLongitude = -118.2437,
                    CreateAt = BitConverter.GetBytes(DateTime.Now.Ticks)  // Current date as binary
                }, 
                new Trip
                {
                    Id = 2,
                    CustomerId = 1,
                    DriverId = 2,
                    Status = TripStatus.Completed,
                    SourceLatitude = 40.7128,
                    SourceLongitude = -74.0060,
                    DestinationLatitude = 34.0522,
                    DestinationLongitude = -118.2437,
                    CreateAt = BitConverter.GetBytes(DateTime.Now.Ticks)
                },
                new Trip
                {
                    Id = 3,
                    CustomerId = 4,
                    DriverId = 2,
                    Status = TripStatus.Completed,
                    SourceLatitude = 51.5074,
                    SourceLongitude = -0.1278,
                    DestinationLatitude = 48.8566,
                    DestinationLongitude = 2.3522,
                    CreateAt = BitConverter.GetBytes(DateTime.Now.Ticks)
                }
            );
        }
    }
}
