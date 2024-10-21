namespace GripOnMash.Controllers
{
    public class ConfirmEmail : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmail(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

        }

        [HttpGet]
        public async Task<IActionResult> ConfermaEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest("Token di conferma non valido.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Impossibile trovare un utente con ID {userId}.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("ConfermaEmail", "ConfirmEmail");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("Error");
        }

    }
}
