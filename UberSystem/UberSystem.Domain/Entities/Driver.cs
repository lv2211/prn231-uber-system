using System.ComponentModel.DataAnnotations.Schema;
using UberSystem.Domain.Enums;

namespace UberSystem.Domain.Entities
{
    public class Driver
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? CabId { get; set; }

        public DateTime? Dob { get; set; }

        public double? LocationLatitude { get; set; }

        public double? LocationLongitude { get; set; }

        public DriverStatus Status { get; set; }

        public byte[] CreateAt { get; set; } = null!;

        public Guid? UserId { get; set; }

        public ICollection<Cab> Cabs { get; } = new List<Cab>();

        public ICollection<Rating> Ratings { get; } = new List<Rating>();

        public ICollection<Trip> Trips { get; } = new List<Trip>();

        public User? User { get; set; }
    }
}
