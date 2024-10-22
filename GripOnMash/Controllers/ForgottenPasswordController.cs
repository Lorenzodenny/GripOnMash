namespace GripOnMash.Controllers
{
    public class ForgottenPasswordController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IValidator<ForgottenPasswordViewModel> _validator;
        private readonly EmailService _emailService;

        public ForgottenPasswordController(
            UserManager<ApplicationUser> userManager,
            IValidator<ForgottenPasswordViewModel> validator,
            EmailService emailService)
        {
            _userManager = userManager;
            _validator = validator;
            _emailService = emailService;
        }

        public IActionResult ForgottenPassword()
        {
            return View(new ForgottenPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgottenPassword(ForgottenPasswordViewModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "L'email non è registrata.");
                return View(model);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "ResetPassword", new { token, email = model.Email }, Request.Scheme);

            await _emailService.SendEmailAsync(model.Email, "Password Dimenticata",
                $"Per reimpostare la tua password, clicca sul link: <a href='{resetLink}'>reimposta la password</a>");

            TempData["Message"] = "Se l'email è registrata, riceverai un'email per reimpostare la password.";
            return RedirectToAction("ForgottenPasswordConfirmation", "ForgottenPasswordConfirmation");
        }


    }

}