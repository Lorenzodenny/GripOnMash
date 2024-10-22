

namespace GripOnMash.Controllers
{
    public class EditMedicoBaseController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;
        private readonly IValidator<EditAccountViewModel> _editAccountValidator;


        public EditMedicoBaseController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, EmailService emailService, IValidator<EditAccountViewModel> editAccountValidator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _editAccountValidator = editAccountValidator ?? throw new ArgumentNullException(nameof(editAccountValidator));
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
    }
}
