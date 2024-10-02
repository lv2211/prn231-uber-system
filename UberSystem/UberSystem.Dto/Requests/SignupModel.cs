using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UberSystem.Dto.Requests
{
    public class SignupModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Role { get; set; } = null!;

        public string UserName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "The minimum length of password is 6 characters!")]
        public required string Password { get; set; }

        [JsonIgnore]
        public string? EmailVerifiedToken { get; set; }
    }
}
