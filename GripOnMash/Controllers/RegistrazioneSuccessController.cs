namespace GripOnMash.Controllers
{
    public class RegistrazioneSuccessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrazioneSuccessController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IActionResult RegistrazioneSuccess()
        {
            return View();
        }
    }
}
