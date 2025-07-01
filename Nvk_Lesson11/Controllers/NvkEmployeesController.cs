using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nvk_Lesson11.Models;

namespace Nvk_Lesson11.Controllers
{
    public class NvkEmployeesController : Controller
    {
        private readonly NguyenVanKhai2310900046Context _context;

        public NvkEmployeesController(NguyenVanKhai2310900046Context context)
        {
            _context = context;
        }

        // GET: NvkEmployees
        public async Task<IActionResult> NvkIndex()
        {
            return View(await _context.NvkEmployees.ToListAsync());
        }

        // GET: NvkEmployees/Details/5
        public async Task<IActionResult> NvkDetails(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var nvkEmployee = await _context.NvkEmployees
                .FirstOrDefaultAsync(m => m.NvkEmpId == nvkID);
            if (nvkEmployee == null)
            {
                return NotFound();
            }

            return View(nvkEmployee);
        }

        // GET: NvkEmployees/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NvkEmpId,NvkEmpName,NvkEmpLevel,NvkEmpStartDate,NvkEmpStatus")] NvkEmployee nvkEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nvkEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvkIndex));
            }
            return View(nvkEmployee);
        }

        // GET: NvkEmployees/Edit/5
        public async Task<IActionResult> NvkEdit(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var nvkEmployee = await _context.NvkEmployees.FindAsync(nvkID);
            if (nvkEmployee == null)
            {
                return NotFound();
            }
            return View(nvkEmployee);
        }

        // POST: NvkEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int nvkID, [Bind("NvkEmpId,NvkEmpName,NvkEmpLevel,NvkEmpStartDate,NvkEmpStatus")] NvkEmployee nvkEmployee)
        {
            if (nvkID != nvkEmployee.NvkEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nvkEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NvkEmployeeExists(nvkEmployee.NvkEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NvkIndex));
            }
            return View(nvkEmployee);
        }

        // GET: NvkEmployees/Delete/5
        public async Task<IActionResult> NvkDelete(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var nvkEmployee = await _context.NvkEmployees
                .FirstOrDefaultAsync(m => m.NvkEmpId == nvkID);
            if (nvkEmployee == null)
            {
                return NotFound();
            }

            return View(nvkEmployee);
        }

        // POST: NvkEmployees/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nvkID)
        {
            var nvkEmployee = await _context.NvkEmployees.FindAsync(nvkID);
            if (nvkEmployee != null)
            {
                _context.NvkEmployees.Remove(nvkEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvkIndex));
        }

        private bool NvkEmployeeExists(int id)
        {
            return _context.NvkEmployees.Any(e => e.NvkEmpId == id);
        }
    }
}
