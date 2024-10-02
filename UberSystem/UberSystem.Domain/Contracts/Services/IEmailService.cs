namespace UberSystem.Domain.Contracts.Services
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string toEmail, string verificationLink);
    }
}
