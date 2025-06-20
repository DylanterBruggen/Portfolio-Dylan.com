using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Dylan_Web.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Main_Admin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Logs()
        {
            return View();
        }
    }
}
