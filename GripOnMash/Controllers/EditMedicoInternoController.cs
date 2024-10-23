namespace GripOnMash.Controllers
{
   // [Authorize(Roles = "Admin")] // Se gli admin possono modificare i medici interni
    public class EditMedicoInternoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditMedicoInternoController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: EditMedicoInterno
        [HttpGet]
     //   [Authorize]
        public async Task<IActionResult> EditMedicoInterno(Guid id)
        {
            // Trova l'utente interno con l'ID specificato
            var internalUser = await _context.InternalUsers.FindAsync(id);

            if (internalUser == null)
            {
                return NotFound();
            }

            // Popola il ViewModel con i dati dell'utente interno
            var model = new EditMedicoInternoViewModel
            {
                Id = internalUser.Id,
                Matricola = internalUser.Matricola,
                Nome = internalUser.Nome,
                Cognome = internalUser.Cognome,
                IsEnabled = internalUser.IsEnabled
            };

            return View(model);
        }

        // POST: EditMedicoInterno
        [HttpPost]
    //    [Authorize]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMedicoInterno(EditMedicoInternoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Trova l'utente interno nel database
            var internalUser = await _context.InternalUsers.FindAsync(model.Id);
            if (internalUser == null)
            {
                return NotFound();
            }

            // Modifica i valori dell'utente interno
            internalUser.Nome = model.Nome;
            internalUser.Cognome = model.Cognome;
            internalUser.Matricola = model.Matricola;
            internalUser.IsEnabled = model.IsEnabled;

            // Salva le modifiche nel database
            _context.Update(internalUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home"); // Reindirizza a una pagina dopo la modifica
        }
    }
}
