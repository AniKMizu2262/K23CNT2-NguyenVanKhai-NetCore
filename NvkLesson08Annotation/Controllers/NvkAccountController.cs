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


        // GET: NvkAccountController
        public ActionResult NvkIndex()
        {
            return View(nvkListAccount);
        }

        // GET: NvkAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvkAccountController/Create
        public ActionResult NvkCreate()
        {
            var nvkModel = new NvkAccount();
            return View(nvkModel);
        }

        // POST: NvkAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NvkAccount nvkModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Gán ID tự động (nếu cần)
                    nvkModel.NvkId = nvkListAccount.Count > 0
                        ? nvkListAccount.Max(x => x.NvkId) + 1
                        : 1;

                    // Thêm vào danh sách tạm
                    nvkListAccount.Add(nvkModel);

                    // Chuyển về danh sách
                    return RedirectToAction(nameof(NvkIndex));
                }

                // Nếu dữ liệu không hợp lệ, hiển thị lại form
                return View(nvkModel);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới: " + ex.Message);
                return View(nvkModel);
            }
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
