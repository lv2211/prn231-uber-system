using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Domain.Entities
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? TripId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Method { get; set; }

        public double? Amount { get; set; }

        public byte[] CreateAt { get; set; } = null!;

        public Trip? Trip { get; set; }
    }
}
