namespace UberSystem.Dto
{
    public class MailSettings
    {
        public string SenderEmail { get; set; } = null!;

        public string? SenderName { get; set; } 
        
        public string Password { get; set; } = null!;
        
        public string SmtpServer { get; set; } = null!;
        
        public int SmtpPort { get; set; }
    }
}
