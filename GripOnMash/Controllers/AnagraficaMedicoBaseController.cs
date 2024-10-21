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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AnagraficaMedicoBaseController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // form di compilazione dell'anagrafica
        [HttpGet]
        public async Task<IActionResult> CompilaAnagrafica()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

           
            var model = new MedicoBaseAnagraficaViewModel
            {
                IdentityId = user.Id
            };

            return View(model); 
        }

        // Salva i dati anagrafici ciao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompilaAnagrafica(MedicoBaseAnagraficaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

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

            return RedirectToAction("Index", "Home"); 
        }
    }
}
