using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ElectronicEquipmentStore.Data;
using ElectronicEquipmentStore.Models;
using ElectronicEquipmentStore.Models.ViewModel;
using ElectronicEquipmentStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicEquipmentStore.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int PageSize = 3;

        public ReceiptController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName=null,string searchEmail=null, string searchPhone=null, string searchDate=null)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ReceiptViewModel receiptVM = new ReceiptViewModel()
            {
                Receipts = new List<Models.Receipt>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Admin/Receipt?productPage=:");
            param.Append("&searchName=");
            if(searchName!=null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            param.Append("&searchDate=");
            if (searchDate != null)
            {
                param.Append(searchDate);
            }


            receiptVM.Receipts = _context.Receipt.Include(a => a.SalePerson).ToList();
            if(User.IsInRole(SD.AdminEndUser))
            {
                receiptVM.Receipts = receiptVM.Receipts.Where(a => a.SalePersonID == claim.Value).ToList();
            }

            if (searchName != null)
            {
                receiptVM.Receipts = receiptVM.Receipts.Where(a => a.tenKH.ToLower().Contains(searchName.ToLower())).ToList();
            }

            if (searchEmail != null)
            {
                receiptVM.Receipts = receiptVM.Receipts.Where(a => a.emailKH.ToLower().Contains(searchEmail.ToLower())).ToList();
            }

            if (searchPhone != null)
            {
                receiptVM.Receipts = receiptVM.Receipts.Where(a => a.sdtKH.ToLower().Contains(searchPhone.ToLower())).ToList();
            }

            if (searchDate != null)
            {
                try
                {
                    DateTime purchaseDate = Convert.ToDateTime(searchDate);
                    receiptVM.Receipts = receiptVM.Receipts.Where(a => a.ngayMua.ToShortDateString().Equals(purchaseDate.ToShortDateString())).ToList();
                }
                catch(Exception ex)
                {

                }
                
            }

            var count = receiptVM.Receipts.Count;

            receiptVM.Receipts = receiptVM.Receipts.OrderBy(p => p.ngayMua)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToList();

            receiptVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };

            return View(receiptVM);
        }

        //Get edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Product>)(from p in _context.Product
                                                     join a in _context.ProductsSelected
                                                     on p.maSP equals a.ProductId
                                                     where a.ReceiptId == id
                                                     select p).Include("ProductGroup");

            ReceiptDetailsViewModel objReceiptVM = new ReceiptDetailsViewModel()
            {
                Receipt=_context.Receipt.Include(a=>a.SalePerson).Where(a=>a.Id==id).FirstOrDefault(),
                SalePerson=_context.ApplicationUser.ToList(),
                Products=productList.ToList()
            };

            return View(objReceiptVM);
        }

        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Product>)(from p in _context.Product
                                                     join a in _context.ProductsSelected
                                                     on p.maSP equals a.ProductId
                                                     where a.ReceiptId == id
                                                     select p).Include("ProductGroup");

            ReceiptDetailsViewModel objReceiptVM = new ReceiptDetailsViewModel()
            {
                Receipt = _context.Receipt.Include(a => a.SalePerson).Where(a => a.Id == id).FirstOrDefault(),
                SalePerson = _context.ApplicationUser.ToList(),
                Products = productList.ToList()
            };

            return View(objReceiptVM);
        }

        //Post Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}