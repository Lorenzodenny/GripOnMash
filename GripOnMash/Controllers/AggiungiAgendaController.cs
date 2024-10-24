namespace GripOnMash.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuth, Identity.Application")]
    public class AggiungiAgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AggiungiAgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AggiungiAgenda()
        {
            var internalUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(internalUserId))
            {
                return BadRequest("ID del medico interno non trovato.");
            }

            ViewBag.InternalUserId = internalUserId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiAgenda(Agenda model, string internalUserId)
        {

            if (string.IsNullOrEmpty(internalUserId))
            {
                return BadRequest("ID del medico interno non trovato.");
            }

            model.InternalUserId = Guid.Parse(internalUserId);

            if (ModelState.IsValid)
            {
                _context.Agende.Add(model);  
                await _context.SaveChangesAsync();

                return RedirectToAction("GetAgendaPerInterno", "GetAgendaPerInterno");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Errore: {error.ErrorMessage}");
            }

            return View(model);
        }


    }
}
