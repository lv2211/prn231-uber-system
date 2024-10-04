using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;

namespace UberSystem.Infrastructure.Data
{
    public static class RatingSeeder
    {
        public static void SeedRatingAndFeedback(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 3,
                    CustomerId = 1,
                    DriverId = 3,
                    TripRating = 5,
                },
                new Rating
                {
                    Id = 4,
                    CustomerId = 1,
                    DriverId = 4,
                    TripRating = 4,
                }
            );
        }
    }
}
