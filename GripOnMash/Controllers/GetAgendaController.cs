namespace GripOnMash.Controllers
{
    public class GetAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetAgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgenda()
        {
            var agende = await _context.Agende
                .Where(a => !a.IsDeleted)
                .ToListAsync();
            return View(agende);
        }
    }
}
