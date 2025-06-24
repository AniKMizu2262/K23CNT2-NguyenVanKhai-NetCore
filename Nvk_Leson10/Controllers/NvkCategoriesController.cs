using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nvk_Leson10.Models;

namespace Nvk_Leson10.Controllers
{
    public class NvkCategoriesController : Controller
    {
        private readonly NvkLesson10Context _context;

        public NvkCategoriesController(NvkLesson10Context context)
        {
            _context = context;
        }

        // GET: NvkCategories
        public async Task<IActionResult> NvkIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NvkCategories/Details/5
        public async Task<IActionResult> NvkDetails(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == nvkID);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NvkCategories/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkCreate([Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvkIndex));
            }
            return View(category);
        }

        // GET: NvkCategories/Edit/5
        public async Task<IActionResult> NvkEdit(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(nvkID);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NvkCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int nvkID, [Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (nvkID != category.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CateId))
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
            return View(category);
        }

        // GET: NvkCategories/Delete/5
        public async Task<IActionResult> NvkDelete(int? nvkID)
        {
            if (nvkID == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == nvkID);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NvkCategories/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nvkID  )
        {
            var category = await _context.Categories.FindAsync(nvkID);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvkIndex));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CateId == id);
        }
    }
}
