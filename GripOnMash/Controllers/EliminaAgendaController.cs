namespace GripOnMash.Controllers
{
    public class EliminaAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<InternalUser> _userManager;

        public EliminaAgendaController(ApplicationDbContext context, UserManager<InternalUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminaAgenda(int id)
        {
            var agenda = await _context.Agende.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            // Verifica che l'agenda appartenga al medico loggato
            var internalUserId = _userManager.GetUserId(User);
            if (agenda.InternalUserId != Guid.Parse(internalUserId))
            {
                return Forbid(); // Non permettere l'eliminazione di un'agenda che non appartiene a questo medico
            }

            agenda.IsDeleted = true;
            _context.Agende.Update(agenda);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetAgendaPerInterno");
        }
    }
}
