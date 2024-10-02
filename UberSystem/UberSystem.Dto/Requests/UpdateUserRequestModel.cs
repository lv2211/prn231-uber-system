using System.ComponentModel.DataAnnotations;

namespace UberSystem.Dto.Requests
{
    /// <summary>
    /// Update model for Customer and Driver
    /// </summary>
    public class UpdateUserRequestModel
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = null!;
    }
}
