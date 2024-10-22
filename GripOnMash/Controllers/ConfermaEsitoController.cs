using Microsoft.AspNetCore.Mvc;

namespace GripOnMash.Controllers
{
    public class ConfermaEsitoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfermaEsitoController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult ConfermaEsito()
        {
            return View();
        }
    }
}
