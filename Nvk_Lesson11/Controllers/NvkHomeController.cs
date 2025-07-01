using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nvk_Lesson11.Models;

namespace Nvk_Lesson11.Controllers
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

        public IActionResult NvkPrivacy()
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
