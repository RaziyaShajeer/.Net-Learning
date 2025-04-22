using amazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace amazon.Controllers
{
    public class itemController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Displayitems()
        {
            var itemlist = context.Items.ToList();
            return View(itemlist);
        }

        [HttpGet]
        public IActionResult Additem() {

            return View();
        }

        [HttpPost]
        public IActionResult Additem(item itm)
        {
            context.Items.Add(itm);
            context.SaveChanges();
            ViewData["message"] = "Added Successfully";
            return View();

        }

        [HttpGet]
        public IActionResult getDetails(int id) {

            item itm = context.Items.Where(e => e.Id == id).FirstOrDefault();
            return View(itm);

        }

        [HttpGet]
        public IActionResult Edit(int id) {
            item itm = context.Items.Where(e => e.Id == id).FirstOrDefault();
            if (itm != null)
            {
                return View(itm);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Edit(item updtitm)
        {
            item olditm = context.Items.Where(e => e.Id == updtitm.Id).FirstOrDefault();
            olditm.Name = updtitm.Name;
            olditm.Description = updtitm.Description;
            olditm.quantity = updtitm.quantity;
            context.Items.Update(olditm);   
            context.SaveChanges();
            ViewBag.message = "Editted Successfully";
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            item st = context.Items.Where(e => e.Id == id).FirstOrDefault();
            if (st != null)
            {
                context.Items.Remove(st);
                context.SaveChanges();

                TempData["message"] = "Item deleted successfully";
            }
            else
            {
                TempData["message"] = "Item not found. Deletion failed";
            }
            return RedirectToAction("Displayitems");
        }



    }
    }
