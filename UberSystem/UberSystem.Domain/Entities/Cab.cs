using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Domain.Entities
{
    public class Cab
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? DriverId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Type { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? RegNo { get; set; }

        // public Driver? Driver { get; set; }

        public ICollection<Driver> Drivers { get; } = new List<Driver>();
    }
}
