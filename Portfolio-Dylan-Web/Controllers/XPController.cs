using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Dylan_Web.Controllers
{
    public class XPController : Controller
    {
        public IActionResult Experience()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }
    }
}