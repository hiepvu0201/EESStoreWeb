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
    public class ProductsController : Controller
    {
        private readonly EESStoreContext _context;

        public ProductsController(EESStoreContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var eESStoreContext = _context.Products.Include(p => p.ProductGroup).Include(p => p.Receipt);
            return View(await eESStoreContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductGroup)
                .Include(p => p.Receipt)
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["maNSP"] = new SelectList(_context.ProductGroups, "maNSP", "maNSP");
            ViewData["maSP"] = new SelectList(_context.Receipts, "maHD", "maHD");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maSP,tenSP,hinhAnh,soLuongSP,giaKhuyenMai,giaGoc,trangThai,maNSX,maNSP")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maNSP"] = new SelectList(_context.ProductGroups, "maNSP", "maNSP", product.maNSP);
            ViewData["maSP"] = new SelectList(_context.Receipts, "maHD", "maHD", product.maSP);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["maNSP"] = new SelectList(_context.ProductGroups, "maNSP", "maNSP", product.maNSP);
            ViewData["maSP"] = new SelectList(_context.Receipts, "maHD", "maHD", product.maSP);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maSP,tenSP,hinhAnh,soLuongSP,giaKhuyenMai,giaGoc,trangThai,maNSX,maNSP")] Product product)
        {
            if (id != product.maSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.maSP))
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
            ViewData["maNSP"] = new SelectList(_context.ProductGroups, "maNSP", "maNSP", product.maNSP);
            ViewData["maSP"] = new SelectList(_context.Receipts, "maHD", "maHD", product.maSP);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductGroup)
                .Include(p => p.Receipt)
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.maSP == id);
        }
    }
}
