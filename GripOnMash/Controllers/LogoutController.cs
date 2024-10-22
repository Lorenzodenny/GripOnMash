using Microsoft.AspNetCore.Mvc;

namespace GripOnMash.Controllers
{
    public class LogoutController : Controller
    {
        private readonly LoginService _ldapService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public LogoutController(LoginService ldapService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _ldapService = ldapService ?? throw new ArgumentNullException(nameof(ldapService)); ;
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Verifica se l'utente è autenticato tramite LDAP
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin")) //&& User.Claims.Any(c => c.Issuer == "LdapAuth")) // Controllo aggiuntivo per vedere se è autenticato con il cookie LdapAuth
            {
                // Recupera la matricola dell'utente LDAP
                var matricola = User.FindFirstValue(ClaimTypes.Name);

                if (string.IsNullOrWhiteSpace(matricola))
                {
                    return BadRequest(AuthenticationError.UserNotFound.ToString());
                }
                if (!string.IsNullOrWhiteSpace(matricola))
                {
                    // Prende l'accesso più recente
                    var internalUserAccess = await _context.InternalUserAccess
                        .AsNoTracking()
                        .Where(i => i.Matricola == matricola && i.Uscita == null)
                        .OrderByDescending(i => i.Accesso)
                        .FirstOrDefaultAsync();

                    if (internalUserAccess == null)
                    {
                        return NotFound(AuthenticationError.LogoutSessionNotFound.ToString());
                    }

                    if (internalUserAccess != null)
                    {
                        // traccia il logout (Uscita)
                        internalUserAccess.Uscita = DateTime.Now;
                        _context.Update(internalUserAccess);
                        await _context.SaveChangesAsync();
                    }
                }

                // Elimina i cookie dell'autenticazione LDAP
                await HttpContext.SignOutAsync("CookieAuth");
            }

            // Effettua il logout per gli utenti Identity
            await _signInManager.SignOutAsync();

            Console.WriteLine("Logout effettuato con successo");

            return RedirectToAction("Login", "Login");
        } 
    }
}
