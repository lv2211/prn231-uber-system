using UberSystem.Domain.Enums;

namespace UberSystem.Domain.Entities
{
    public class Trip
    {
        public long Id { get; set; }

        public long? CustomerId { get; set; }

        public long? DriverId { get; set; }

        public long? PaymentId { get; set; }

        public TripStatus Status { get; set; }

        public double? SourceLatitude { get; set; }

        public double? SourceLongitude { get; set; }

        public double? DestinationLatitude { get; set; }

        public double? DestinationLongitude { get; set; }

        public byte[] CreateAt { get; set; } = null!;

        public Customer? Customer { get; set; }

        public Driver? Driver { get; set; }

        public ICollection<Payment> Payments { get; } = new List<Payment>();

        public ICollection<Rating> Ratings { get; } = new List<Rating>();
    }
}
