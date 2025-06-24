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

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var from = _smtpSettings.From;
            var to = _smtpSettings.To;
            var host = _smtpSettings.Host;
            var port = _smtpSettings.Port;
            var username = _smtpSettings.Username;
            var password = _smtpSettings.Password;

            var subject = $"New Contact Message from {model.Name}";
            var body = $"Name: {model.Name}\nEmail: {model.Email}\n\nMessage:\n{model.Message}";

            using var client = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            try
            {
                var mail = new MailMessage(from, to, subject, body);
                await client.SendMailAsync(mail);

                TempData["SuccessMessage"] = "Your message was sent successfully!";
                return RedirectToAction("Contact");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending contact email.");
                ModelState.AddModelError("", "Failed to send message. " + ex.Message);
                return View(model);
            }
        }
    }
}
