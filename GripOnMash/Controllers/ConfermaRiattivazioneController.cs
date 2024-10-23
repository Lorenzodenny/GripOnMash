using Microsoft.AspNetCore.Mvc;

namespace GripOnMash.Controllers
{
    public class ConfermaRiattivazioneController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly EmailHelper _emailHelper;
        private readonly IValidator<CreateUserViewModel> _createUserValidator;

        public ConfermaRiattivazioneController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, EmailHelper emailHelper, IValidator<CreateUserViewModel> createUserValidator)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailHelper = emailHelper ?? throw new ArgumentNullException(nameof(emailHelper));
            _createUserValidator = createUserValidator ?? throw new ArgumentNullException(nameof(createUserValidator));
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfermaRiattivazione(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = false;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("ConfermaRiattivazione");
        }

    }
}
