using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVCSample.Models;

namespace MVCSample.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public String getname()
        {
            return "My name is Fara";
        }

        [HttpGet]
        public IActionResult ListStudent()
        {
            var stdlist = context.Students.ToList();
            return View(stdlist);

        }
        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            return View();
        }
    }
}