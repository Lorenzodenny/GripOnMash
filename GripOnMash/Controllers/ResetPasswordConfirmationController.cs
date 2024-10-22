using Microsoft.AspNetCore.Mvc;

namespace GripOnMash.Controllers
{
    public class ResetPasswordConfirmationController : Controller
    {
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
