using Microsoft.AspNetCore.Identity;

namespace GripOnMash.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginService _ldapService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;  


        public AccountController(LoginService ldapService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _ldapService = ldapService ?? throw new ArgumentNullException(nameof(ldapService)); ;
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string input, string password)
        {
            if (IsEmail(input))
            {
                ApplicationUser user = null;

                // Cerca l'utente tramite email o username
                if (IsEmail(input))
                {
                    user = await _userManager.FindByEmailAsync(input);
                }
                else
                {
                    // Se non è un'email, consideriamo che sia un UserName
                    user = await _userManager.FindByNameAsync(input);
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Utente non trovato.");
                    return View();
                }

                // Verifica il risultato di PasswordSignInAsync
                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    Console.WriteLine("Login riuscito");
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ModelState.AddModelError("", "Tentativo di accesso non valido.");
                }
            }
            else
            {
                var ldapAuthenticated = await LoginService.LoginLdap(input, password);
                if (ldapAuthenticated)
                {
                    // Recupera l'utente dal database
                    var user = await _context.InternalUsers
                        .Include(u => u.InternalUserRoles)
                        .FirstOrDefaultAsync(u => u.Matricola == input);

                    if (user is null)
                        return NotFound(AuthenticationError.UserNotFound.ToString());
                    if (!user.IsEnabled)
                        return BadRequest(AuthenticationError.UserNotEnable.ToString());

                    // Crea la sessione/cookie per l'utente LDAP autenticato
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Matricola)
                    };

                    // Aggiungi i ruoli come claim
                    foreach (var role in user.InternalUserRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.RoleId));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, "LdapAuth");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true // Imposta la sessione persistente o no
                    };

                    // Effettua il login utilizzando i cookie di autenticazione con lo schema CookieAuth in progrma.cs
                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Traccia l'accesso del login dell'interno
                    var accesso = new InternalUserAccess(0,
                        user.Matricola,
                        DateTime.Now,
                        null,
                        DateTime.Now.AddHours(1),
                        null);

                    _context.InternalUserAccess.Add(accesso);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tentativo di accesso con Ldap non valido.");
            }

            return View();
        }

        private bool IsEmail(string input)
        {
            return input.Contains("@");
        }
    }
}
