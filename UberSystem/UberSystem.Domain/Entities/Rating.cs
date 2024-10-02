using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Domain.Entities
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? DriverId { get; set; }

        public long? TripId { get; set; }

        public int? TripRating { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string? Feedback { get; set; }

        public Customer? Customer { get; set; }

        public Driver? Driver { get; set; }

        public Trip? Trip { get; set; }
    }
}
