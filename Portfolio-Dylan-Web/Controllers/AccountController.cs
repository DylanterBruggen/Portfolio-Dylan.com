using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Dylan_Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
