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
          var students=  studentrepository.GetStudents();
            
            return View(students);
        }
    }
}
