using Microsoft.AspNetCore.Mvc;
using NvkLab06.Models;

namespace NvkLab06.Controllers
{
    public class NvkEmployeeController : Controller
    {
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
        public IActionResult NvkIndex()
        {
            return View(nvkListEmployees);
        }

        public IActionResult NvkCreate()
        {
            return View();
        }

    }
}
