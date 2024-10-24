namespace GripOnMash.Controllers
{
   // [Authorize(AuthenticationSchemes = "CookieAuth, Identity.Application", Roles = "Admin")]

    public class DeleteAccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;


        public DeleteAccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
     //   [Authorize]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("GetMediciBase", "GetMediciBase");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("GetMediciBase", "GetMediciBase");
        }

    }
}
