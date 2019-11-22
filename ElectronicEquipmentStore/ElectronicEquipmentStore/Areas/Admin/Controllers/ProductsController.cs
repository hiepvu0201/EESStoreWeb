using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicEquipmentStore.Data;
using ElectronicEquipmentStore.Models;
using Microsoft.AspNetCore.Authorization;
using ElectronicEquipmentStore.Utility;
using ElectronicEquipmentStore.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;

namespace ElectronicEquipmentStore.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

            ProductVM = new ProductViewModel()
            {
                ProductGroups = _context.ProductGroup.ToList(),
                Categories = _context.Category.ToList(),
                Product = new Product()
            };

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

        // GET: Details Action Method
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Create Action Method
        public IActionResult Create()
        {
            return View(ProductVM);
        }

        // GET: drop down


        // POST: Create Action Method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(ProductVM);
            //}
            _context.Product.Add(ProductVM.Product);

            //Image being saved
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _context.Product.Find(ProductVM.Product.maSP);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductVM.Product.maSP + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                productsFromDb.hinhAnh = @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + ".png");
                productsFromDb.hinhAnh = @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + ".png";
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit Action Method
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductVM.Product = await _context.Product.Include(m => m.ProductGroup).Include(m => m.Category).SingleOrDefaultAsync(m => m.maSP == id);

            if (ProductVM.Product == null)
            {
                return NotFound();
            }
            return View(ProductVM);
        }

        // POST: Edit Action Method
        [HttpPost, ActionName("Edit")]   
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(string id)
        {
            if(ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _context.Product.Where(m => m.maSP == ProductVM.Product.maSP).FirstOrDefault();

                if(files[0].Length>0 && files[0]!=null)
                {
                    //if user upload a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(productFromDb.hinhAnh);

                    if(System.IO.File.Exists(Path.Combine(uploads, ProductVM.Product.maSP+extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ProductVM.Product.maSP + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ProductVM.Product.maSP + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    ProductVM.Product.hinhAnh = @"\" + SD.ImageFolder + @"\" + ProductVM.Product.maSP + extension_new;
                }
                if(ProductVM.Product.hinhAnh!=null)
                {
                    productFromDb.hinhAnh = ProductVM.Product.hinhAnh;
                }
                productFromDb.tenSP= ProductVM.Product.tenSP;
                productFromDb.soLuongSP = ProductVM.Product.soLuongSP;
                productFromDb.giaKhuyenMai = ProductVM.Product.giaKhuyenMai;
                productFromDb.giaGoc = ProductVM.Product.giaGoc;
                productFromDb.trangThai = ProductVM.Product.trangThai;
                productFromDb.maNSX = ProductVM.Product.maNSX;
                productFromDb.maNSP = ProductVM.Product.maNSP;
                productFromDb.maDM = ProductVM.Product.maDM;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ProductVM);
            }

        // GET: Delete Action Method
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.maSP == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Delete Action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Product.Any(e => e.maSP == id);
        }
    }
}
