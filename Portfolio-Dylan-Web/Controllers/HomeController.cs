using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Dylan_Web.Models;
using Microsoft.Extensions.Options;

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
    }
}
