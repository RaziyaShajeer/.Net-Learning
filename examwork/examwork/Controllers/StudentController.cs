using examwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace examwork.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListStudents()
        {
           var stdlist= _context.students.ToList();
            return View(stdlist);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(student std)
        {
            _context.students.Add(std);
            _context.SaveChanges();
            ViewData["message"] = "Added successfully";
            return View();
        }

        [HttpGet]

        public IActionResult GetDetails(int id) 
        { 

            student std=_context.students.Where(e=>e.Id==id).FirstOrDefault();
            return View(std);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        { 
            student std=_context.students.Where(e=>e.Id==id).FirstOrDefault();
            if (std != null) { 
                return View(std);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]

        public IActionResult Edit(student newstd)
        {
            student oldstd=_context.students.Where(e=>e.Id==newstd.Id).FirstOrDefault();
            oldstd.Name = newstd.Name;
            oldstd.Description = newstd.Description;
            oldstd.Age = newstd.Age;
            _context.students.Update(oldstd);
            _context.SaveChanges();
            ViewBag.message = "Editted Successfully";
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        { 
            student st=_context.students.Where(e=>e.Id == id).FirstOrDefault();
            if (st != null) { 
                _context.students.Remove(st);
                _context.SaveChanges();

                TempData["message"] = "std deleted";
            }
            else
            {
                TempData["message"] = "std not found";
            }
            return RedirectToAction("ListStudents");
        }
    }


}
