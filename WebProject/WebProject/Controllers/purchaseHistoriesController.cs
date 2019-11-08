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
    public class purchaseHistoriesController : Controller
    {
        private readonly EESStoreContext _context;

        public purchaseHistoriesController(EESStoreContext context)
        {
            _context = context;
        }

        // GET: purchaseHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseHistories.ToListAsync());
        }

        // GET: purchaseHistories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistories
                .FirstOrDefaultAsync(m => m.maPurchaseHistory == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // GET: purchaseHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: purchaseHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maPurchaseHistory,maHD")] purchaseHistory purchaseHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseHistory);
        }

        // GET: purchaseHistories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistories.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }
            return View(purchaseHistory);
        }

        // POST: purchaseHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maPurchaseHistory,maHD")] purchaseHistory purchaseHistory)
        {
            if (id != purchaseHistory.maPurchaseHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!purchaseHistoryExists(purchaseHistory.maPurchaseHistory))
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
            return View(purchaseHistory);
        }

        // GET: purchaseHistories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseHistory = await _context.PurchaseHistories
                .FirstOrDefaultAsync(m => m.maPurchaseHistory == id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return View(purchaseHistory);
        }

        // POST: purchaseHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var purchaseHistory = await _context.PurchaseHistories.FindAsync(id);
            _context.PurchaseHistories.Remove(purchaseHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool purchaseHistoryExists(string id)
        {
            return _context.PurchaseHistories.Any(e => e.maPurchaseHistory == id);
        }
    }
}
