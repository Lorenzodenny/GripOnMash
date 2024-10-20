namespace GripOnMash.Controllers
{
    public class AuthController : Controller
    {
        private readonly LoginService _ldapService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AuthController(LoginService ldapService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
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

        [HttpPost] // LOGIN IDENTITY PER MEDICI DI BASE
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (IsEmail(model.Input))
            {
                ApplicationUser user = null;

                // Cerca l'utente tramite email o username
                if (IsEmail(model.Input))
                {
                    user = await _userManager.FindByEmailAsync(model.Input);
                }
                else
                {
                    // Se non è un'email, consideriamo che sia un UserName
                    user = await _userManager.FindByNameAsync(model.Input);
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Utente non trovato.");
                    return View();
                }

                // Verifica il risultato di PasswordSignInAsync
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

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
            else // LOGIN LDAP PER GLI INTERNI
            {
                var ldapAuthenticated = await LoginService.LoginLdap(model.Input, model.Password);
                if (ldapAuthenticated)
                {
                    // Recupera l'utente dal database
                    var user = await _context.InternalUsers
                        .Include(u => u.InternalUserRoles)
                        .FirstOrDefaultAsync(u => u.Matricola == model.Input);

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
                        // traccia il logout
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

            return RedirectToAction("Login", "Auth");
        }
    }
}
