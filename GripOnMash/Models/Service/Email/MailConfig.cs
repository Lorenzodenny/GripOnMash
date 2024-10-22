namespace GripOnMash.Models.Service.Email
{
    public class MailConfig
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool EnableSsl { get; set; } = true;  // Default SSL a true
        public bool Enable { get; set; } = true;     
    }
}
