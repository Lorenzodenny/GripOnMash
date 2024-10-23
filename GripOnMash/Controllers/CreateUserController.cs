namespace GripOnMash.Controllers
{
   // [Authorize(AuthenticationSchemes = "CookieAuth, Identity.Application", Roles = "Admin")]

    public class CreateUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly EmailHelper _emailHelper; 
        private readonly IValidator<CreateUserViewModel> _createUserValidator;

        public CreateUserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, EmailHelper emailHelper, IValidator<CreateUserViewModel> createUserValidator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailHelper = emailHelper ?? throw new ArgumentNullException(nameof(emailHelper)); 
            _createUserValidator = createUserValidator ?? throw new ArgumentNullException(nameof(createUserValidator));
        }

        // [Authorize(Roles = "Admin")]
        [Authorize]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        //  [Authorize(Roles = "Admin")]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            var validationResult = await _createUserValidator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                try
                {
                    // Genera una password casuale
                    string randomPassword = PasswordGenerator.Generate();
                    Console.WriteLine("PASSWORD GENERATA: " + randomPassword, ConsoleColor.Green);

                    // Crea l'utente
                    var user = new ApplicationUser
                    {
                        UserName = model.Email, 
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Nome = model.Nome, 
                        Cognome = model.Cognome, 
                        IsDeleted = false,
                        CodiceOtp = "CodiceOtpDaInventare"
                    };

                    var result = await _userManager.CreateAsync(user, randomPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                        // Email di benveniubbo
                        await _emailHelper.SendWelcomeEmail(user, randomPassword);

                        // Genera il token di conferma email
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        await _emailHelper.SendConfirmationEmail(user, token, Url);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore durante la creazione dell'utente: " + ex.Message);
                    ModelState.AddModelError("", "Si è verificato un errore durante la creazione dell'utente.");
                }
            }

            return View(model);
        }
    }
}

