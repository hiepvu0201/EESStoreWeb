using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ProductGroupsController : Controller
    {
        private readonly EESStoreContext _context;

        public ProductGroupsController(EESStoreContext context)
        {
            _context = context;
        }

        // GET: ProductGroups
        public async Task<IActionResult> Index()
        {
            var eESStoreContext = _context.ProductGroups.Include(p => p.Category);
            return View(await eESStoreContext.ToListAsync());
        }

        // GET: ProductGroups/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroups
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.maNSP == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: ProductGroups/Create
        public IActionResult Create()
        {
            ViewData["maDM"] = new SelectList(_context.Categories, "maDM", "maDM");
            return View();
        }

        // POST: ProductGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maNSP,tenNSP,soLuongSpMoiNhom,maDM")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maDM"] = new SelectList(_context.Categories, "maDM", "maDM", productGroup.maDM);
            return View(productGroup);
        }

        // GET: ProductGroups/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroups.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }
            ViewData["maDM"] = new SelectList(_context.Categories, "maDM", "maDM", productGroup.maDM);
            return View(productGroup);
        }

        // POST: ProductGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maNSP,tenNSP,soLuongSpMoiNhom,maDM")] ProductGroup productGroup)
        {
            if (id != productGroup.maNSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGroupExists(productGroup.maNSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["maDM"] = new SelectList(_context.Categories, "maDM", "maDM", productGroup.maDM);
            return View(productGroup);
        }

        // GET: ProductGroups/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroups
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.maNSP == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productGroup = await _context.ProductGroups.FindAsync(id);
            _context.ProductGroups.Remove(productGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductGroupExists(string id)
        {
            return _context.ProductGroups.Any(e => e.maNSP == id);
        }
    }
}
