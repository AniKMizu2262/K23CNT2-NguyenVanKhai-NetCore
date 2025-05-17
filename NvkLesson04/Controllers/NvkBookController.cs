using Microsoft.AspNetCore.Mvc;
using NvkLesson04.Models;
using System.Collections.Generic;

namespace NvkLesson04.Controllers
{
    public class NvkBookController : Controller
    {
        private List<NvkBook> nvkBooks = new List<NvkBook>
        {
            new NvkBook
            {
                NvkId = "B001",
                NvkTitle = "Bài tập toán 7",
                NvkDescription = "Sách bài tập cải thiện môn toán 7",
                NvkImage = "Imgage/baitaptoan7.jpg",
                NvkPrice = 32f,
                NvkPage = 100
            },
            new NvkBook
            {
                NvkId = "B002",
                NvkTitle = "Hóa học 12",
                NvkDescription = "Sách giáo khoa môn Hóa Học 7 ",
                NvkImage = "Imgage/hoahoc.png",
                NvkPrice = 27f,
                NvkPage = 190
            },
            new NvkBook
            {
                NvkId = "B003",
                NvkTitle = "Sách Ngữ Văn 7 ",
                NvkDescription = "Sách giáo khoa môn Ngữ Văn 7 ",
                NvkImage = "Imgage/ngu-van-7-tap-1-144.jpg",
                NvkPrice = 25f,
                NvkPage = 198
            },
            new NvkBook
            {
                NvkId = "B004",
                NvkTitle = "Sách Tiếng Nhật 7 ",
                NvkDescription = "Sách giáo khoa môn Tiếng Nhật 7 ",
                NvkImage = "Imgage/tiengnhat7.jpg",
                NvkPrice = 35f,
                NvkPage = 276
            },
            new NvkBook
            {
                NvkId = "B005",
                NvkTitle = "Sách toán 7",
                NvkDescription = "Sách giáo khoa môn Toán 7 ",
                NvkImage = "Imgage/toan7.png",
                NvkPrice = 15f,
                NvkPage = 180
            }
        };

        // Get: NvkBook/NvkIndex => lấy danh sách cuốn sách 
        public IActionResult NvkIndex()
        {
            // Đưa dữ liệu lên views 

            return View(nvkBooks);
        }

        // Get: NvkBook/NvkCreate
        public IActionResult NvkCreate()
        {
            NvkBook NvkBook = new NvkBook();
            return View(nvkBooks);
        }

        // Post: NvkBook/NvkCreateSumbit
        public IActionResult NvkCreateSumbit()
        {
            return RedirectToAction("NvkIndex");
        }

        // Get: NvkBook/NvkCreate
        public IActionResult NvkEdit(string id)
        {
            return View();

        }

        // Get: NvkBook/NvkCreate
        public IActionResult NvkEditSumbit()
        {
            
            return View(NvkIndex);
        }
    }
}