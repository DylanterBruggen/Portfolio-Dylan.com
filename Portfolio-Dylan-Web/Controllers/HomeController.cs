using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Dylan_Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;

namespace Portfolio_Dylan_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmtpSettings _smtpSettings;

        public HomeController(
            ILogger<HomeController> logger,
            IOptions<SmtpSettings> smtpOptions)
        {
            _logger = logger;
            _smtpSettings = smtpOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            try
            {
                // Validate culture
                var supportedCultures = new[] { "en", "nl" };
                if (!supportedCultures.Contains(culture))
                {
                    culture = "en"; // Default to English
                }

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        IsEssential = true // Make cookie essential for GDPR
                    }
                );

                // Ensure returnUrl is local to prevent open redirect attacks
                if (!Url.IsLocalUrl(returnUrl))
                {
                    returnUrl = Url.Content("~/");
                }

                return LocalRedirect(returnUrl);
            }
            catch
            {
                // Fallback if something goes wrong
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
