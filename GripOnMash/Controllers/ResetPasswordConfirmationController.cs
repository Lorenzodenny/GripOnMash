namespace GripOnMash.Controllers
{
    public class ResetPasswordConfirmationController : Controller
    {
        public IActionResult ResetPasswordConfirmation()
        {
            // return View();
            return RedirectToAction("Login", "Login");

        }
    }
}
