namespace GripOnMash.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuth")]
    public class GetAgendaPerInternoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetAgendaPerInternoController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetAgendaPerInterno()
        {
            var internalUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Funziona

            if (string.IsNullOrEmpty(internalUserId))
            {
                return Unauthorized("Utente non autenticato.");
            }

            var internalUserGuid = Guid.Parse(internalUserId);

            var agende = await _context.Agende
                .Where(a => a.InternalUserId == internalUserGuid && !a.IsDeleted)
                .ToListAsync();

            return View(agende);
        }
    }
}
