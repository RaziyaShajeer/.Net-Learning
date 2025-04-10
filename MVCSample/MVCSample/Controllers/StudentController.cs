using System.Linq;
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

        [HttpGet]
        public IActionResult getdetails(int id)
        {
           Student st = context.Students.Where(e => e.Id == id).FirstOrDefault();
            return View(st);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student st=context.Students.Where(e=>e.Id == id).FirstOrDefault();
            if (st != null) { 
                return View(st);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Student updtdstd) {
            Student oldstd = context.Students.Where(e => e.Id == updtdstd.Id).FirstOrDefault();
            oldstd.Name=updtdstd.Name;
            oldstd.Description=updtdstd.Description;
            oldstd.emaiId=updtdstd.emaiId;
            oldstd.Password=updtdstd.Password;
            context.Students.Update(oldstd);
            context.SaveChanges();
            ViewBag.message = "Edited Successfully";
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id) { 
            Student st=context.Students.Where(e=>e.Id==id).FirstOrDefault();
            if (st != null) { 
                context.Students.Remove(st);
                context.SaveChanges();
                return RedirectToAction("ListStudent");
            }
            else
            {
                return RedirectToAction("ListStudent");
            }

        }


        
    }
}