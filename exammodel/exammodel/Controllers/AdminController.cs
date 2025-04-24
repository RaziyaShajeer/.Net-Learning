using exammodel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exammodel.Controllers
{
    public class AdminController : Controller
    {

        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListTeachers()
        {
            var tealist = _context.teachers.ToList();
            return View(tealist);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(teacher tea)
        {
            _context.teachers.Add(tea);
            _context.SaveChanges();
            ViewData["message"] = "Added successfully";
            return View();
        }

        [HttpGet]

        public IActionResult GetDetails(int id)
        {

            teacher tea = _context.teachers.Where(e=>e.Id==id).FirstOrDefault();
            return View(tea);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            teacher tea = _context.teachers.Where(e => e.Id == id).FirstOrDefault();
            if (tea != null)
            {
                return View(tea);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]

        public IActionResult Edit(teacher newtea)
        {
            teacher oldtea = _context.teachers.Where(e => e.Id == newtea.Id).FirstOrDefault();
            oldtea.Name = newtea.Name;
            oldtea.Description = newtea.Description;
            oldtea.Age = newtea.Age;
            _context.teachers.Update(oldtea);
            _context.SaveChanges();
            ViewBag.message = "Editted Successfully";
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            teacher tea = _context.teachers.Where(e => e.Id == id).FirstOrDefault();
            if (tea != null)
            {
                _context.teachers.Remove(tea);
                _context.SaveChanges();

                TempData["message"] = "deleted Successfully";
            }
            else
            {
                TempData["message"] = " not found";
            }
            return RedirectToAction("ListTeachers");
        }
    }

}

