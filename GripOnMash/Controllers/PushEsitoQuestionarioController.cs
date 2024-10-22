using GripOnMash.Models;

public class PushEsitoQuestionarioController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PushEsitoQuestionarioController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    [HttpGet]
    public IActionResult PushEsito()
    {
        var domande = _context.Domande
        .Include(d => d.Risposte)
        .ToList();

        if (domande == null || domande.Count == 0)
        {
            return View("Errore", "Nessuna domanda trovata");
        }

        return View(domande);
    }

    [HttpPost]
    public async Task<IActionResult> PushEsito(PushEsitoQuestionarioViewModel model)
    {
        var medicoBaseId = _userManager.GetUserId(User);

        if (medicoBaseId == null)
        {
            return BadRequest("ID del medico non trovato.");
        }

        Console.WriteLine($"UserId recuperato: {medicoBaseId}");

        if (ModelState.IsValid)
        {
            var esito = new EsitoQuestionario
            {
                MedicoBaseId = medicoBaseId, 
                PazienteIdoneo = model.PazienteIdoneo
            };

            _context.EsitoQuestionari.Add(esito);
            await _context.SaveChangesAsync();

            foreach (var rispostaSelezionata in model.RisposteSelezionate)
            {
                var rispostaEsito = new RisposteEsitoQuestionario
                {
                    EsitoQuestionarioId = esito.EsitoQuestionarioId,
                    DomandaId = rispostaSelezionata.DomandaId,
                    RispostaId = rispostaSelezionata.RispostaId
                };

                _context.RisposteEsitoQuestionari.Add(rispostaEsito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ConfermaEsito", "ConfermaEsito");
        }

        return View("PushEsito", model);
    }



}
