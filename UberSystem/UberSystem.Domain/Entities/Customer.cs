using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Domain.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public byte[] CreateAt { get; set; } = null!;

        public Guid? UserId { get; set; }

        public ICollection<Rating> Ratings { get; } = new List<Rating>();

        public ICollection<Trip> Trips { get; } = new List<Trip>();

        public User? User { get; set; }
    }
}
