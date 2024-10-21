using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GripOnMash.Models;
using GripOnMash.ViewModel;

namespace GripOnMash.Controllers
{
    [Authorize]
    public class AnagraficaMedicoBaseController : Controller
    {
        private readonly IValidator<MedicoBaseAnagraficaViewModel> _anagraficaValidator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AnagraficaMedicoBaseController(IValidator<MedicoBaseAnagraficaViewModel> anagraficaValidator, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _anagraficaValidator = anagraficaValidator ?? throw new ArgumentNullException(nameof(anagraficaValidator)); ;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager)); ;
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        // form di compilazione dell'anagrafica
        [HttpGet]
        public async Task<IActionResult> CompilaAnagrafica()
        {
            Console.WriteLine("Caricamento form anagrafica...");
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("Utente non trovato.");
                return NotFound();
            }

            Console.WriteLine($"Utente trovato: {user.UserName}");
            var model = new MedicoBaseAnagraficaViewModel
            {
                IdentityId = user.Id
            };

            return View(model); 
        }

        // Salva i dati anagrafici a
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompilaAnagrafica(MedicoBaseAnagraficaViewModel model)
        {
            Console.WriteLine("Ricevuto il form per la compilazione anagrafica...");

            var validationResult = await _anagraficaValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(model);
            }

            Console.WriteLine("ModelState valido, inizio salvataggio...");
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("Utente non trovato.");
                return NotFound();
            }

            Console.WriteLine($"Salvataggio anagrafica per l'utente: {user.UserName}");
            // Crea l'anagrafica e salva nel DB
            var anagrafica = new MedicoBaseAnagrafica
            {
                IdentityId = user.Id,
                Nome = model.Nome,
                Cognome = model.Cognome,
                Eta = model.Eta,
                NumeroTelefono = model.NumeroTelefono,
                CodiceFiscale = model.CodiceFiscale,
                Indirizzo = model.Indirizzo,
                Specializzazione = model.Specializzazione,
                NumeroAlbo = model.NumeroAlbo,
                EmailPersonale = model.EmailPersonale,
                PartitaIVA = model.PartitaIVA
            };

            _context.MedicoBaseAnagrafiche.Add(anagrafica);
            await _context.SaveChangesAsync();

            Console.WriteLine("Anagrafica salvata con successo.");
            return RedirectToAction("Index", "Home"); 
        }
    }
}
