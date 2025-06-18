using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Dylan_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Main_Admin()
        {
            return View();
        }

        public IActionResult Logs()
        {
            return View();
        }
    }
}
