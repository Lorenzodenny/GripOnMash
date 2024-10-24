namespace GripOnMash.MiddleWare
{
    public class CheckIfDeletedMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public CheckIfDeletedMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                // Crea uno scope per accedere ai servizi "scoped"
                using (var scope = _scopeFactory.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();

                    // Ottieni l'utente loggato
                    var user = await userManager.GetUserAsync(context.User);

                    if (user != null && user.IsDeleted)
                    {
                        await signInManager.SignOutAsync();
                        context.Response.Redirect("/Login/Login");
                        return;
                    }
                }
            }

            // Passa la richiesta al middleware successivo
            await _next(context);
        }
    }
}
