namespace GripOnMash.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            Console.WriteLine("Logout Identity iniziato");

            await _signInManager.SignOutAsync();
            Console.WriteLine("Logout Effettuato per i medici base");

            return RedirectToAction("Login", "Login");
        }
    }
}
