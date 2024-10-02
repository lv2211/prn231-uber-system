using System.ComponentModel.DataAnnotations.Schema;
using UberSystem.Domain.Enums;

namespace UberSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? UserName { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserRole Role { get; set; }

        public bool? EmailVerified { get; set; }

        public string? VerifiedToken { get; set; }

        public ICollection<Customer> Customers { get; } = new List<Customer>();

        public ICollection<Driver> Drivers { get; } = new List<Driver>();
    }
}
