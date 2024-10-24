namespace GripOnMash.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuth")]
    public class GetMediciBaseController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public GetMediciBaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<IActionResult> GetMediciBase()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }
    }
}
