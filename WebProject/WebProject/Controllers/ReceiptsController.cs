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
    public class ReceiptsController : Controller
    {
        private readonly EESStoreContext _context;

        public ReceiptsController(EESStoreContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            var eESStoreContext = _context.Receipts.Include(r => r.Customer).Include(r => r.PurchaseHistory);
            return View(await eESStoreContext.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.Customer)
                .Include(r => r.PurchaseHistory)
                .FirstOrDefaultAsync(m => m.maHD == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            ViewData["maKH"] = new SelectList(_context.Customers, "maKH", "maKH");
            ViewData["maHD"] = new SelectList(_context.PurchaseHistories, "maPurchaseHistory", "maPurchaseHistory");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maHD,maSP,ngayGiaoDich,soLuongSP,donGia,thanhTieh,tongTien,maKH,tenKH")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maKH"] = new SelectList(_context.Customers, "maKH", "maKH", receipt.maKH);
            ViewData["maHD"] = new SelectList(_context.PurchaseHistories, "maPurchaseHistory", "maPurchaseHistory", receipt.maHD);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["maKH"] = new SelectList(_context.Customers, "maKH", "maKH", receipt.maKH);
            ViewData["maHD"] = new SelectList(_context.PurchaseHistories, "maPurchaseHistory", "maPurchaseHistory", receipt.maHD);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maHD,maSP,ngayGiaoDich,soLuongSP,donGia,thanhTieh,tongTien,maKH,tenKH")] Receipt receipt)
        {
            if (id != receipt.maHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.maHD))
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
            ViewData["maKH"] = new SelectList(_context.Customers, "maKH", "maKH", receipt.maKH);
            ViewData["maHD"] = new SelectList(_context.PurchaseHistories, "maPurchaseHistory", "maPurchaseHistory", receipt.maHD);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.Customer)
                .Include(r => r.PurchaseHistory)
                .FirstOrDefaultAsync(m => m.maHD == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(string id)
        {
            return _context.Receipts.Any(e => e.maHD == id);
        }
    }
}
