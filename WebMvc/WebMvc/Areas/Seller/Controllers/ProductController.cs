using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMvc.Data;
//using WebMvc.Migrations;
using WebMvc.Models;

namespace WebMvc.Areas.Seller.Controllers
{
    [Area("Seller")]

    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController (ApplicationDbContext db)
        {   
            this._db = db;
        }


        public IActionResult Index()
        {
           var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ProductModel> products = _db.ProductModel.Where(a=>a.UserId== UserId).Include(a=> a.Category).ToList();

            return View(products);
        }




        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_db.catagoryModel, "CatagoryId", "CatagoryName");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            ViewBag.Category = new SelectList(_db.catagoryModel, "CatagoryId", "CatagoryName");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //file(images)uploading
            var Filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Uploads", model.MyFile.FileName);
            var stream = new FileStream(Filepath, FileMode.Create);
            await model.MyFile.CopyToAsync(stream);
            model.Image = model.MyFile.FileName;
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _db.ProductModel.AddAsync(model);
            var res = await _db.SaveChangesAsync();
            if (res > 0)
                return RedirectToAction(nameof(Index));

            return View(model);
        }


        


        public async Task<IActionResult> Edit(int id)
        {
            ProductModel Product = await _db.ProductModel.FindAsync(id);
            ViewBag.Category = new SelectList(_db.catagoryModel, "CatagoryId", "CatagoryName",Product.Id);
           
            return View(Product);

        }




        [HttpPost]
        public async Task <IActionResult> Edit(ProductModel model)
        {
            ViewBag.Category = new SelectList(_db.catagoryModel, "CatagoryId", "CatagoryName");
            if (!ModelState.IsValid)
                 return View(model);
            if(model.MyFile?.FileName != null)
            {
                var FilePath =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Uploads", model.MyFile.FileName);
                var stream = new FileStream(FilePath, FileMode.Create);
                await model.MyFile.CopyToAsync(stream);
                model.Image = model.MyFile.FileName;
            }
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _db.ProductModel.Update(model);
            var res = await _db.SaveChangesAsync();
            if (res > 0)
                return RedirectToAction(nameof(Index));

            return View(model);


        }




        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");
            ProductModel product = await _db.ProductModel.FindAsync(Id);
            return View(product);
        }






        public async Task<IActionResult> Delete(int Id)
        {
            ProductModel cty = await _db.ProductModel.FindAsync(Id);
            _db.ProductModel.Remove(cty);
            var res = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        





    }
}
