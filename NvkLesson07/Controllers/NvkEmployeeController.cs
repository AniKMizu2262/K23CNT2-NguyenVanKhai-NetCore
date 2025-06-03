using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvkLesson07.Models;
using System.Linq;

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

        // GET: NvkEmployeeController/Details/{id}
        public ActionResult NvkDetails(string id)
        {
            var employee = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: NvkEmployeeController/NvkCreate
        public ActionResult NvkCreate()
        {
            return View(new NvkEmployee());
        }

        // POST: NvkEmployeeController/NvkCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkCreate(NvkEmployee nvkModel)
        {
            try
            {
                // Tạo Id mới (simple - tăng số cuối nếu có)
                string newId = "EMP" + (nvkListEmployees.Count + 1).ToString("D3");
                nvkModel.NvkId = newId;
                nvkListEmployees.Add(nvkModel);
                return RedirectToAction(nameof(NvkIndex));
            }
            catch
            {
                return View(nvkModel);
            }
        }

        // GET: NvkEmployeeController/NvkEdit/{id}
        public ActionResult NvkEdit(string id)
        {
            var nvkEmployee = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
            if (nvkEmployee == null) return NotFound();
            return View(nvkEmployee);
        }

        // POST: NvkEmployeeController/NvkEdit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkEdit(string id, NvkEmployee updatedModel)
        {
            try
            {
                var emp = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
                if (emp == null) return NotFound();

                // Cập nhật thông tin
                emp.NvkName = updatedModel.NvkName;
                emp.NvkBirthDay = updatedModel.NvkBirthDay;
                emp.NvkEmail = updatedModel.NvkEmail;
                emp.NvkPhone = updatedModel.NvkPhone;
                emp.NvkSalary = updatedModel.NvkSalary;
                emp.NvkStatus = updatedModel.NvkStatus;

                return RedirectToAction(nameof(NvkIndex));
            }
            catch
            {
                return View(updatedModel);
            }
        }

        // GET: NvkEmployeeController/NvkDelete/{id}
        public ActionResult NvkDelete(string id)
        {
            var emp = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: NvkEmployeeController/NvkDelete/{id}
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NvkDeleteConfirmed(string id)
        {
            try
            {
                var emp = nvkListEmployees.FirstOrDefault(x => x.NvkId == id);
                if (emp == null) return NotFound();
                nvkListEmployees.Remove(emp);
                return RedirectToAction(nameof(NvkIndex));
            }
            catch
            {
                return RedirectToAction(nameof(NvkIndex));
            }
        }
    }
}