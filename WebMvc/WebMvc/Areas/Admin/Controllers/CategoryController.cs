using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMvc.Data;
//using WebMvc.Migrations;
using WebMvc.Models;

namespace WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //HttpContext.Request.
            List<catagoryModel> Categories = _db.catagoryModel.ToList();
            //var categories = _db.catagoryModel.ToList();
            return View(Categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(catagoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _db.catagoryModel.AddAsync(model);
            var res = await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult>Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");
            catagoryModel category = await _db.catagoryModel.FindAsync(Id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null) return RedirectToAction("Index");
            catagoryModel category = await _db.catagoryModel.FindAsync(Id);
            return View(category);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(catagoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            _db.catagoryModel.Update(model);
            var res = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int Id)
        {
            catagoryModel cty = await _db.catagoryModel.FindAsync(Id);
            _db.catagoryModel.Remove(cty);
            var res = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Items(int id)
        {
            List<ProductModel>Products = _db.ProductModel.Where(a=>a.CategoryId ==id).ToList();
            return View(Products);

        }


    }
}
