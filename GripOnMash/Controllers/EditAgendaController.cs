namespace GripOnMash.Controllers
{
    public class EditAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditAgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> EditAgenda(int id)
        {
            var agenda = await _context.Agende.FindAsync(id);
            if (agenda == null || agenda.IsDeleted)
            {
                return NotFound();
            }

            var internalUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(internalUserId) || agenda.InternalUserId != Guid.Parse(internalUserId))
            {
                return Forbid(); 
            }

            return View(agenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAgenda(Agenda model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Agende.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetAgendaPerInterno");
        }
    }
}
