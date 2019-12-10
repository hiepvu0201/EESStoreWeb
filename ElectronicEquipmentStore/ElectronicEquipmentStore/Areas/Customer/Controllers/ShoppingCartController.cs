    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicEquipmentStore.Data;
using ElectronicEquipmentStore.Extensions;
using ElectronicEquipmentStore.Models;
using ElectronicEquipmentStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicEquipmentStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Models.Product>()
            };
        }

        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<string> lstShoppingCart = HttpContext.Session.Get<List<string>>("ssShoppingCart");

            if (lstShoppingCart!=null)
            {
                foreach(string cartItem in lstShoppingCart)
                {
                    Product prod = _context.Product.Include(p=>p.ProductGroup).Where(p => p.maSP == cartItem).FirstOrDefault();
                    ShoppingCartVM.Products.Add(prod);
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<string> lstCartItems = HttpContext.Session.Get<List<string>>("ssShoppingCart");

            ShoppingCartVM.Receipt.ngayMua = DateTime.Now;

            Receipt receipt = ShoppingCartVM.Receipt;
            _context.Receipt.Add(receipt);
            _context.SaveChanges();

            int receiptId = receipt.Id;

            foreach (string productId in lstCartItems)
            {
                ProductsSelected productsSelected = new ProductsSelected()
                {
                    ReceiptId=receiptId,
                    ProductId=productId
                };
                _context.ProductsSelected.Add(productsSelected);
            }
            _context.SaveChanges();

            lstCartItems = new List<string>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction("ReceiptConfirmation", "ShoppingCart", new { id= receiptId });
        }

        public IActionResult Remove(string id)
        {
            List<string> lstCartItems = HttpContext.Session.Get<List<string>>("ssShoppingCart");

            if (lstCartItems != null)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart",lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReceiptConfirmation(int id)
        {
            ShoppingCartVM.Receipt = _context.Receipt.Where(a => a.Id == id).FirstOrDefault();
            List<ProductsSelected> objProList = _context.ProductsSelected.Where(p => p.ReceiptId == id).ToList();

            foreach (ProductsSelected receiptObj in objProList)
            {
                ShoppingCartVM.Products.Add(_context.Product.Include(p => p.ProductGroup).Where(p => p.maSP == receiptObj.ProductId).FirstOrDefault());
            }

            return View(ShoppingCartVM);
        }
    }   
}