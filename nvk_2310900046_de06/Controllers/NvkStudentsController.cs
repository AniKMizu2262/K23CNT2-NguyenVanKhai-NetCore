using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nvk_2310900046_de06.Models;

namespace nvk_2310900046_de06.Controllers
{
    public class NvkStudentsController : Controller
    {
        private readonly NguyenVanKhai2310900046De06Context _context;

        public NvkStudentsController(NguyenVanKhai2310900046De06Context context)
        {
            _context = context;
        }

        // GET: NvkStudents
        public async Task<IActionResult> NvkIndex()
        {
            return View(await _context.NvkStudents.ToListAsync());
        }

        // GET: NvkStudents/Details/5
        public async Task<IActionResult> NvkDetails(int? nvkID)
        {
            if (nvkID == null)
                return NotFound();

            var student = await _context.NvkStudents.FirstOrDefaultAsync(m => m.NvkStudId == nvkID);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: NvkStudents/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkStudents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkCreate([Bind("NvkStudId,NvkStudName,NvkStudAge,NvkStudGender,NvkEmail,NvkStudStatus")] NvkStudent student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvkIndex));
            }
            return View(student);
        }

        // GET: NvkStudents/Edit/5
        public async Task<IActionResult> NvkEdit(int? nvkID)
        {
            if (nvkID == null)
                return NotFound();

            var student = await _context.NvkStudents.FindAsync(nvkID);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: NvkStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int nvkID, [Bind("NvkStudId,NvkStudName,NvkStudAge,NvkStudGender,NvkEmail,NvkStudStatus")] NvkStudent student)
        {
            if (nvkID != student.NvkStudId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.NvkStudents.Any(e => e.NvkStudId == student.NvkStudId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(NvkIndex));
            }
            return View(student);
        }

        // GET: NvkStudents/Delete/5
        public async Task<IActionResult> NvkDelete(int? nvkID)
        {
            if (nvkID == null)
                return NotFound();

            var student = await _context.NvkStudents.FirstOrDefaultAsync(m => m.NvkStudId == nvkID);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: NvkStudents/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nvkID)
        {
            var student = await _context.NvkStudents.FindAsync(nvkID);
            if (student != null)
                _context.NvkStudents.Remove(student);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvkIndex));
        }
    }
}