using FluentValidation;
using GripOnMash.Service;

namespace GripOnMash.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;
        private readonly IValidator<EditAccountViewModel> _editAccountValidator;
        private readonly IValidator<CreateUserViewModel> _createUserValidator;


        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, EmailService emailService, IValidator<EditAccountViewModel> editAccountValidator, IValidator<CreateUserViewModel> createUserValidator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _editAccountValidator = editAccountValidator ?? throw new ArgumentNullException(nameof(editAccountValidator));
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
                    string randomPassword = PasswordGenerator.GenerateRandomPassword();
                    Console.WriteLine("PASSWORD GENERATA: " + randomPassword, ConsoleColor.Green);

                    // Crea l'utente
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    };

                    var result = await _userManager.CreateAsync(user, randomPassword);

                    if (result.Succeeded)
                    {

                        var roleResult = await _userManager.AddToRoleAsync(user, "User");

                        if (roleResult.Succeeded)
                        {
                            // Invia email con la password
                            if (!string.IsNullOrWhiteSpace(model.Email))
                            {
                                string subject = "Benvenuto! Il tuo account è stato creato";
                                string body = $"Ciao {user.UserName},<br><br>La tua password temporanea è: <strong>{randomPassword}</strong><br>Per favore, effettua il login e cambia la tua password al più presto.";

                                await _emailService.SendEmailAsync(model.Email, subject, body);
                                Console.WriteLine("Email inviata a: " + model.Email);
                            }

                            // Genera il token di conferma email
                            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var confirmationLink = Url.Action("ConfirmEmail", "Email",
                                new { userId = user.Id, token = token }, Request.Scheme);

                            // Link per la compilazione del form anagrafico 
                            var anagraficaLink = Url.Action("CompilaAnagrafica", "AnagraficaMedicoBase", null, Request.Scheme);

                            // Invia la seconda email con i due link
                            string confirmationSubject = "Conferma il tuo account";
                            string confirmationBody = $"Ciao {user.UserName},<br><br>Per favore, <a href='{confirmationLink}'>conferma la tua email</a> per attivare il tuo account.<br><br>" +
                                $"Dopo aver confermato la tua email, <a href='{anagraficaLink}'>compila il form anagrafico</a> per completare il profilo.";

                            await _emailService.SendEmailAsync(model.Email, confirmationSubject, confirmationBody);
                            Console.WriteLine("Email di conferma inviata a: " + model.Email);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
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




        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditAccountViewModel
            {
                UserName = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAccountViewModel model, string formType)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            if (formType == "account")
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!string.IsNullOrWhiteSpace(model.UserName) && model.UserName != user.UserName)
                {
                    user.UserName = model.UserName;
                }

                if (!string.IsNullOrWhiteSpace(model.Email) && model.Email != user.Email)
                {
                    user.Email = model.Email;
                }

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // Mantiene l'utente autenticato dopo l'aggiornamento
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", "Home");
            }
            else if (formType == "password")
            {
                if (!string.IsNullOrWhiteSpace(model.CurrentPassword) && !string.IsNullOrWhiteSpace(model.NewPassword))
                {
                    if (model.NewPassword != model.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "La nuova password e la conferma non coincidono.");
                        return View(model);
                    }

                    var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (!passwordChangeResult.Succeeded)
                    {
                        foreach (var error in passwordChangeResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }

                    // Mantiene l'utente autenticato dopo l'aggiornamento della password
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "La password non può essere vuota.");
                return View(model);
            }

            return BadRequest("Tipo di form non riconosciuto.");
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();  // Logout
                return RedirectToAction("Login", "Auth");  
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("Edit");  
        }
    }
}
