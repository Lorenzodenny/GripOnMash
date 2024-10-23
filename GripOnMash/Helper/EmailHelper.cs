using GripOnMash.Helper.Services;

namespace GripOnMash.Helper
{
    public class EmailHelper
    {
        private readonly EmailService _emailService;

        public EmailHelper(EmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task SendWelcomeEmail(ApplicationUser user, string randomPassword)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(user.Email))
                {
                    string subject = "Benvenuto! Il tuo account è stato creato";
                    string body = $"Ciao {user.UserName},<br><br>La tua password temporanea è: <strong>{randomPassword}</strong><br>Per favore, effettua il login e cambia la tua password al più presto.";

                    await _emailService.SendEmailAsync(user.Email, subject, body);
                    Console.WriteLine("Email inviata a: " + user.Email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante l'invio dell'email: " + ex.Message);
                Console.WriteLine("Dettagli completi: " + ex.ToString());
            }
        }

        public async Task SendConfirmationEmail(ApplicationUser user, string token, IUrlHelper urlHelper)
        {
            try
            {
                var confirmationLink = urlHelper.Action("ConfermaEmail", "ConfirmEmail", new { userId = user.Id, token = token }, "http");
                var anagraficaLink = urlHelper.Action("LoginAnagrafica", "LoginAnagrafica", null, "http");

                string confirmationSubject = "Conferma il tuo account";
                string confirmationBody = $"Ciao {user.UserName},<br><br>Per favore, <a href='{confirmationLink}'>conferma la tua email</a> per attivare il tuo account.<br><br>" +
                    $"Dopo aver confermato la tua email, <a href='{anagraficaLink}'>loggati e compila il form anagrafico</a> per completare il profilo.";

                await _emailService.SendEmailAsync(user.Email, confirmationSubject, confirmationBody);
                Console.WriteLine("Email di conferma inviata a: " + user.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante l'invio dell'email: " + ex.Message);
                Console.WriteLine("Dettagli completi: " + ex.ToString());
            }

        }

    }
}
