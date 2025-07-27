using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Portfolio_Dylan_Web.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public DocumentsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult ViewDocument() => View();

        [HttpGet]
        public IActionResult Download(string filename)
        {
            var filepath = Path.Combine(_env.WebRootPath, "files", filename);
            if (!System.IO.File.Exists(filepath))
                return NotFound();

            return File(System.IO.File.ReadAllBytes(filepath),
                        "application/octet-stream", filename);
        }
    }
}