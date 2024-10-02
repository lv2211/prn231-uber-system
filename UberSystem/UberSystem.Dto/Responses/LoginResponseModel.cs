namespace UberSystem.Dto.Responses
{
    public class LoginResponseModel
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; } = null!;

        public string? Role { get; set; }

        public string AccessToken { get; set; } = null!;
    }
}
