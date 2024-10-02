namespace UberSystem.Dto.Responses
{
    /// <summary>
    /// Response model used for Customer and Driver
    /// </summary>
    public class UserResponseModel
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; } = null!;

        public byte[] CreateAt { get; set; } = null!;
    }
}
