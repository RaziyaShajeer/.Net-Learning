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
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
       
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
    
}
