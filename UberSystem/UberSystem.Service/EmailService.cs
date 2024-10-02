using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Dto;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace UberSystem.Service
{
    public class EmailService(IOptions<MailSettings> mailSettings) : IEmailService
    {
        private readonly MailSettings _mailSettings = mailSettings.Value;

        public async Task SendVerificationEmailAsync(string toEmail, string verificationLink)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress("", toEmail));
            email.Subject = "Account Verification";
            email.Body = new TextPart("plain")
            {
                Text = $"Please click this link to verify your email address: {verificationLink}"
            };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.SenderEmail, _mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
