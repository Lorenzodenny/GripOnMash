namespace GripOnMash.Helper.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _context;

        public EmailService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                // Recupera la configurazione dal database
                //var emailConfig = await _context.MailConfigs
                //    .AsNoTracking()
                //    .FirstOrDefaultAsync(m => m.Enable);
                var emailConfig = await _context.MailConfigs
                       .AsNoTracking()
                       .FirstOrDefaultAsync(m => m.Id == 1); // 1 mia, 2 gemelli

                if (emailConfig == null)
                {
                    Console.WriteLine("Configurazione email non trovata.");
                    return;
                }

                Console.WriteLine($"Tentativo di connessione a SMTP: {emailConfig.Host}:{emailConfig.Port}, SSL: {emailConfig.EnableSsl}");
                Console.WriteLine($"Username: {emailConfig.Username}, From: {emailConfig.FromAddress}");

                // Crea il messaggio di posta
                using var message = new MailMessage(emailConfig.FromAddress, to, subject, body)
                {
                    IsBodyHtml = true
                };

                // Configura il client SMTP
                using var smtpClient = new SmtpClient(emailConfig.Host, emailConfig.Port)
                {
                    EnableSsl = emailConfig.EnableSsl
                };

                // Imposta le credenziali solo se necessarie
                if (!string.IsNullOrWhiteSpace(emailConfig.Username) && !string.IsNullOrWhiteSpace(emailConfig.Password))
                {
                    smtpClient.Credentials = new NetworkCredential(emailConfig.Username, emailConfig.Password);
                }

                // Invia il messaggio
                await smtpClient.SendMailAsync(message);
                Console.WriteLine("Email inviata con successo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante l'invio dell'email: " + ex.Message);
                Console.WriteLine("Dettagli completi: " + ex.ToString());
            }
        }
    }

}
