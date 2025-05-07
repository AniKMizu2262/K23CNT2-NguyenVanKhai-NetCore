using Microsoft.AspNetCore.Mvc;

namespace Nvk_Lesson02.Controllers
{
    public class NvkProductController : Controller
    {
        public IActionResult NvkIndex()
        {
            ViewData["messageData"] = "Dữ liệu từ viewData";
            ViewBag.messageData = "Dữ liệu từ viewBag";
            TempData["messageData"] = "Dữ liệu từ tempData";
            return View();
        }
    }
}
