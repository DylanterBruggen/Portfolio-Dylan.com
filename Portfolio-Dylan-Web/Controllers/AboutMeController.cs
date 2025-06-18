using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Dylan_Web.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
