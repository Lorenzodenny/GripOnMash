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
        public async Task<IActionResult> Logout()
        {
            Console.WriteLine("Logout iniziato"); // Verifica se entra nel metodo

            // Controlla se esiste il cookie LDAP
            if (Request.Cookies["auth_cookie_grip_on_mash"] != null)
            {
                Console.WriteLine("Cookie LDAP trovato");

                var matricola = User.FindFirstValue(ClaimTypes.Name);
                Console.WriteLine($"Matricola trovata: {matricola}");

                if (!string.IsNullOrWhiteSpace(matricola))
                {
                    // Traccia il logout per LDAP
                    await HttpContext.SignOutAsync("CookieAuth"); // Logout per LDAP
                    Console.WriteLine("Effettuato logout LDAP");
                }
            }

            // Effettua il logout per gli utenti Identity
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme); // Logout per Identity
            Console.WriteLine("Effettuato logout Identity");

            return RedirectToAction("Login", "Login");
        }


    }
}
