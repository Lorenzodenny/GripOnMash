﻿namespace GripOnMash.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _ldapService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly CookieCrypt _cookieCrypt;

        public LoginController(LoginService ldapService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, CookieCrypt cookieCrypt)
        {
            _ldapService = ldapService ?? throw new ArgumentNullException(nameof(ldapService)); ;
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cookieCrypt = cookieCrypt ?? throw new ArgumentNullException(nameof(cookieCrypt));  
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Se il medico di base è già autenticato invia al quiz
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("PushEsito", "PushEsitoQuestionario"); 
            }

            // Verifica se il cookie personalizzato (LDAP) esiste
            var matricolaCookie = Request.Cookies["matricola_cookie"];
            var authCookie = Request.Cookies["auth_cookie_grip_on_mash"];

            // Se il medico interno è già autenticato, quindi esistono entrambi i cookie invialo a Index di Home
            if (!string.IsNullOrEmpty(matricolaCookie) && !string.IsNullOrEmpty(authCookie))
            {
                var decryptedMatricola = _cookieCrypt.Decrypt(matricolaCookie);

                if (!string.IsNullOrEmpty(decryptedMatricola))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
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
                ApplicationUser? user = null;

                // Cerca l'utente tramite email o username
                if (IsEmail(model.Input))
                {
                    user = await _userManager.FindByEmailAsync(model.Input);
                }
                else
                {
                    // Se non è un'email, consideriamo che sia un UserName
                    user = await _userManager.FindByNameAsync(model.Input); // giusto
                }

                if (user is null) // is = a "==" piu performante
                {
                    ModelState.AddModelError("", "Utente non trovato.");
                    return View();
                }

                if (string.IsNullOrEmpty(user.UserName))
                {
                    ModelState.AddModelError("", "Utente non trovato.");
                    return View();
                }
                if(user.IsDeleted is true)
                {
                    ModelState.AddModelError("", "Utente disabilitato.");
                    return View();
                }

                // Verifica il risultato di PasswordSignInAsync
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    Console.WriteLine("Login riuscito");
                    return RedirectToAction("PushEsito", "PushEsitoQuestionario");
                }
                else
                {

                    ModelState.AddModelError("", "Tentativo di accesso non valido.");
                }
            }
            else // LOGIN LDAP PER GLI INTERNI
            {
                //var ldapAuthenticated = await LoginService.LoginLdap(model.Input, model.Password);
                //if (ldapAuthenticated)
                //{
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
                        new Claim(ClaimTypes.Name, user.Matricola),
                        new Claim("NomeX", user.Nome),  
                        new Claim("CognomeX", user.Cognome)
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

                    if (user != null)
                    {
                        // Cripta la matricola
                        var encryptedMatricola = _cookieCrypt.Encrypt(user.Matricola);

                        // Crea il cookie personalizzato per salvare la matricola criptata
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddHours(1),
                            HttpOnly = true
                        };

                        // Imposta il cookie con la matricola criptata
                        Response.Cookies.Append("matricola_cookie", encryptedMatricola, cookieOptions);
                    }


                    // Effettua il login utilizzando i cookie di autenticazione con lo schema CookieAuth in progrma.cs
                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Traccia il login (Entrata)
                    var accesso = new InternalUserAccess(0,
                        user.Matricola,
                        DateTime.Now,
                        null,
                        DateTime.Now.AddHours(1),
                        null);

                    _context.InternalUserAccess.Add(accesso);

                    await _context.SaveChangesAsync();

                    Console.WriteLine("Tentativo di login con LDAP VALIDO");
                    return RedirectToAction("Index", "Home");
                //}
                Console.WriteLine("Tentativo di login con LDAP non valido");
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
