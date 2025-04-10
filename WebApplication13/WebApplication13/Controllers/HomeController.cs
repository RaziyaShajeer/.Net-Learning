using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Interface;
using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.Controllers;

public class HomeController : Controller
{
    IStudentrepository studentrepository = new StudentRepository();

    private readonly ILogger<HomeController> _logger;
    ApplicationDbContext context = new ApplicationDbContext();
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public IActionResult Getstudents()
    {
        var students = studentrepository.GetStudents();


        return View(students);
    }
}
