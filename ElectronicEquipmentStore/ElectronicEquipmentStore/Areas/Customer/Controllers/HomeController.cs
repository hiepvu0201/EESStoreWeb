using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElectronicEquipmentStore.Models;
using ElectronicEquipmentStore.Data;
using Microsoft.EntityFrameworkCore;
using ElectronicEquipmentStore.Extensions;
using Microsoft.AspNetCore.Http;

namespace ElectronicEquipmentStore.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var products = from m in _context.Product select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.tenSP.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }
 
        public async Task<IActionResult> Details(string id)
        {
            var product = await _context.Product.Include(m => m.ProductGroup).Where(m => m.maSP == id).FirstOrDefaultAsync();
            return View(product);
        }

        [HttpPost,ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPost(string id)
        {
            List<string> lstShoppingCart = HttpContext.Session.Get<List<string>>("ssShoppingCart");
            if(lstShoppingCart==null)
            {
                lstShoppingCart = new List<string>();
            }
            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart",lstShoppingCart);
            return RedirectToAction("Index","Home",new { area="Customer"});
        }

        public ActionResult Remove(string id)
        {
            List<string> lstShoppingCart = HttpContext.Session.Get<List<string>>("ssShoppingCart");
            if(lstShoppingCart.Count>0)
            {
                if(lstShoppingCart.Contains(id))
                {
                    lstShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart",lstShoppingCart);

            return RedirectToAction(nameof(Index));
        }
    }
}
