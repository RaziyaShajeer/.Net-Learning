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
            return View();
        
        }


    }
}
