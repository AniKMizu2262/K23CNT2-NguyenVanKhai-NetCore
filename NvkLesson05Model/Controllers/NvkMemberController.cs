using Microsoft.AspNetCore.Mvc;
using NvkLesson05Model.Models.DataModels;

namespace NvkLesson05Model.Controllers
{
    public class NvkMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NvkGetMember() 
        {
            var nvkMember = new NvkMember();
            nvkMember.NvkMemberID = Guid.NewGuid().ToString();
            nvkMember.NvkUserName = "AniKmizu2262";
            nvkMember.NvkFullName = "Nguyễn Văn Khải";
            nvkMember.NvkPassword = "pass123";
            nvkMember.NvkEmail = "nguyenvankhai2262@gmail.com";

            ViewBag.nvkMember = nvkMember;
            return View();
        }
    }
}
