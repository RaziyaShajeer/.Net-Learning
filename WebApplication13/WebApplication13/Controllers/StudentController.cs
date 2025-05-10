using Microsoft.AspNetCore.Mvc;
using WebApplication13.Interface;
using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.Controllers
{
    public class StudentController : Controller
    {
        IStudentrepository studentrepository = new StudentRepository();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Getstudents()
        {
            var students = studentrepository.GetStudents();

            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var std = studentrepository.AddStudent(student);
            return View(std);
        }

        [HttpGet]
        public IActionResult FindStudent(int id)
        {
            var std = studentrepository.FindStudent(id);
            if (std != null)
            {
                return View(std);
            }
            else
            {
                return View();
            }


        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student) 
        {
            var oldstd = studentrepository.UpdateStudent(student);
            oldstd.Name=student.Name;
            oldstd.Email=student.Email;
            studentrepository.UpdateStudent(oldstd);
            ViewBag.message = "Edited Successfully";
            return View();
    }
        [HttpPost]
        public IActionResult Login(string email)
        {
            studentrepository.Login(email);
            HttpContext.Session.SetString("Email", email);
            return View();
        }
}
    }