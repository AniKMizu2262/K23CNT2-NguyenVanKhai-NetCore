using Microsoft.AspNetCore.Mvc;

namespace nvk_Lesson01Mvc.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
