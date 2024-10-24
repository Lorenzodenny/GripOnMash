namespace GripOnMash.Controllers
{
    public class LogoutInterniController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CookieCrypt _cookieCrypt;

        public LogoutInterniController(ApplicationDbContext context, CookieCrypt cookieCrypt)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cookieCrypt = cookieCrypt ?? throw new ArgumentNullException(nameof(cookieCrypt));
        }

        [HttpPost]
        public async Task<IActionResult> LogoutInterni()
        {
            Console.WriteLine("Logout LDAP iniziato");

            // Recupera il valore criptato del cookie
            var encryptedMatricola = Request.Cookies["matricola_cookie"];

            if (!string.IsNullOrEmpty(encryptedMatricola))
            {
                // Decripta la matricola
                var matricola = _cookieCrypt.Decrypt(encryptedMatricola);
                Console.WriteLine($"Matricola decriptata: {matricola}");

                // Recupera l'ultimo accesso dell'utente LDAP basato sulla matricola
                var ultimoAccesso = await _context.InternalUserAccess
                    .Where(a => a.Matricola == matricola)
                    .OrderByDescending(a => a.Accesso)
                    .FirstOrDefaultAsync();

                if (ultimoAccesso != null)
                {
                    // Aggiorna l'uscita
                    ultimoAccesso.Uscita = DateTime.Now;
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Campo 'Uscita' aggiornato correttamente");
                }
            }

            // Cancella i cookie
            Response.Cookies.Delete("auth_cookie_grip_on_mash");
            Response.Cookies.Delete("matricola_cookie");
            Console.WriteLine("Cookie LDAP cancellato manualmente");

            await HttpContext.SignOutAsync("CookieAuth");
            Console.WriteLine("Effettuato logout LDAP tramite CookieAuth");

            return RedirectToAction("Login", "Login");
        }
    }
}
