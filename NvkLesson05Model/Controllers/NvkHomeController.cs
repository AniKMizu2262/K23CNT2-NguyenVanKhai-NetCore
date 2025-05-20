using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using NvkLesson05Model.Models;

namespace NvkLesson05Model.Controllers
{
    public class NvkHomeController : Controller
    {
        private readonly ILogger<NvkHomeController> _logger;

        public NvkHomeController(ILogger<NvkHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NvkIndex()
        {
            return View();
        }

        public IActionResult NvkAbout()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
