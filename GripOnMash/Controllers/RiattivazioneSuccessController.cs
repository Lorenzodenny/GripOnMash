using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GripOnMash.Controllers
{
    public class RiattivazioneSuccessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiattivazioneSuccessController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        public IActionResult RiattivazioneSuccess()
        {
            return View();
        }
    }
}
