//namespace GripOnMash.Service
//{
//    public class EmailService
//    {
//        private readonly IConfiguration _configuration;

//        public EmailService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task SendEmailAsync(string toEmail, string subject, string body)
//        {
//            var smtpConfig = _configuration.GetSection("Smtp");
//            var smtpClient = new SmtpClient(smtpConfig["Host"])
//            {
//                Port = int.Parse(smtpConfig["Port"]),
//                Credentials = new NetworkCredential(smtpConfig["Username"], smtpConfig["Password"]),
//                EnableSsl = bool.Parse(smtpConfig["EnableSsl"]),
//            };

//            var mailMessage = new MailMessage
//            {
//                From = new MailAddress(smtpConfig["Username"]),
//                Subject = subject,
//                Body = body,
//                IsBodyHtml = true
//            };
//            mailMessage.To.Add(toEmail);

//            await smtpClient.SendMailAsync(mailMessage);
//        }
//    }

//}
