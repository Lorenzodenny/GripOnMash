using Microsoft.AspNetCore.Mvc;

namespace GripOnMash.Controllers
{
    public class ForgottenPasswordConfirmationController : Controller
    {
        public IActionResult ForgottenPasswordConfirmation()
        {
            return View();
        }
    }
}
