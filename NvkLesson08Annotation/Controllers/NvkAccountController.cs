using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvkLesson08Annotation.Models;

namespace NvkLesson08Annotation.Controllers
{
    public class NvkAccountController : Controller
    {
        // Danh sách tài khoản (list giả lập dữ liệu)
        private static List<NvkAccount> nvkListAccount = new List<NvkAccount>()
        {
             new NvkAccount
    {
        NvkId = 2310900046,
        NvkFullName = "Nguyễn Văn Khải",
        NvkEmail = "nguyenvankhai2262@gmail.com",
        NvkPhone = "0347903565",
        NvkAddress = "Uy Nỗ, Đông Anh, Hà Nội",
        NvkAvatar = "/images/avatar1.png",
        NvkBirthday = new DateTime(2005, 7, 10),
        NvkGender = "Nam",
        NvkPassword = "Password123",
        NvkFacebook = "https://www.facebook.com/AniKMizu2262/"
    },
    new NvkAccount
    {
        NvkId = 2,
        NvkFullName = "Trần Thị B",
        NvkEmail = "tranthib@example.com",
        NvkPhone = "091-234-5678",
        NvkAddress = "456 Đường XYZ, Hà Nội",
        NvkAvatar = "/images/avatar2.jpg",
        NvkBirthday = new DateTime(1998, 8, 15),
        NvkGender = "Nữ",
        NvkPassword = "MySecurePass456",
        NvkFacebook = "https://facebook.com/tranthib"
    },
    new NvkAccount
    {
        NvkId = 3,
        NvkFullName = "Lê Minh Cường",
        NvkEmail = "lecuong@example.com",
        NvkPhone = "098-765-4321",
        NvkAddress = "789 Đường DEF, Đà Nẵng",
        NvkAvatar = "/images/avatar3.png",
        NvkBirthday = new DateTime(2000, 12, 5),
        NvkGender = "Nam",
        NvkPassword = "CuongPass789",
        NvkFacebook = "https://facebook.com/lecuong"
    }
        };


        // GET: NvkAccount/NvkIndex
        public IActionResult NvkIndex()
        {
            return View(nvkListAccount);
        }

        // GET: NvkAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvkAccount/NvkCreate
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkAccount/NvkCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NvkCreate(NvkAccount model)
        {
            if (ModelState.IsValid)
            {
                // Tạo ID tự tăng (nếu cần)
                model.NvkId = nvkListAccount.Count > 0
                    ? nvkListAccount.Max(x => x.NvkId) + 1
                    : 1;
                nvkListAccount.Add(model);
                return RedirectToAction("NvkIndex");
            }
            return View(model);
        }



        // GET: NvkAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NvkAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvkAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
