using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvkLesson07.Models;

namespace NvkLesson07.Controllers
{
    public class NvkEmployeeController : Controller
    {
        // Mock data 
        private static List<NvkEmployee> nvkListEmployees = new List<NvkEmployee>()
        {
            new NvkEmployee
            {
                NvkId = "2310900046",
                NvkName = "Nguyễn Văn Khải",
                NvkBirthDay = new DateTime(2005, 7, 10),
                NvkEmail = "nguyenvankhai2262@gmail.com",
                NvkPhone = "0347903565",
                NvkSalary = 12000000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = "EMP002",
                NvkName = "Tran Thi B",
                NvkBirthDay = new DateTime(1988, 8, 30),
                NvkEmail = "tranthib@example.com",
                NvkPhone = "0938765432",
                NvkSalary = 13500000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = "EMP003",
                NvkName = "Le Van C",
                NvkBirthDay = new DateTime(1995, 2, 20),
                NvkEmail = "levanc@example.com",
                NvkPhone = "0905123456",
                NvkSalary = 9800000,
                NvkStatus = false
            },
            new NvkEmployee
            {
                NvkId = "EMP004",
                NvkName = "Pham Thi D",
                NvkBirthDay = new DateTime(1992, 11, 15),
                NvkEmail = "phamthid@example.com",
                NvkPhone = "0967890123",
                NvkSalary = 14500000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = "EMP005",
                NvkName = "Hoang Van E",
                NvkBirthDay = new DateTime(1987, 6, 5),
                NvkEmail = "hoangvane@example.com",
                NvkPhone = "0971234567",
                NvkSalary = 11000000,
                NvkStatus = false
            }
        };
        // GET: NvkEmployeeController
        public ActionResult NvkIndex()
        {
            return View(nvkListEmployees);
        }

        // GET: NvkEmployeeController/Details/5
        public ActionResult NvkDetails(int id)
        {
            return View();
        }

        // GET: NvkEmployeeController/NvkCreate
        public ActionResult NvkCreate()
        {
            var NvkEmployee = new NvkEmployee();
            return View();
        }

        // POST: NvkEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkCreate(NvkEmployee nvkModel )
        {
            try
            {
                // Thêm mới nhân viên vào list
                nvkModel.NvkId = nvkListEmployees.Max(x => x.NvkId) +1;
                nvkListEmployees.Add(nvkModel);
                return RedirectToAction(nameof(NvkIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkEmployeeController/Edit/5
        public ActionResult NvkEdit(string id)
        {
            var nvkEmployee = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
            return View(nvkEmployee);
        }

        // POST: NvkEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkEdit(int id, IFormCollection collection)
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

        // GET: NvkEmployeeController/Delete/5
        public ActionResult NvkDelete(int id)
        {
            return View();
        }

        // POST: NvkEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkDelete(int id, IFormCollection collection)
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
