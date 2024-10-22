namespace GripOnMash.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Questa action verrà chiamata quando l'utente clicca sul link nella mail di reset password
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                return BadRequest("Token non valido o email mancante.");
            }

            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        // Questa action gestisce la richiesta di reset della password
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Non rivelare che l'email non esiste nel sistema
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

       
    }
}
