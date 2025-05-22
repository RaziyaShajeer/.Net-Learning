using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingSystem.Controllers
{
    public class AdminController : Controller
    {
        IMapper mapper;
        MyDbContext _context = new MyDbContext();

        public AdminController(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLocation(LocationDTO locationDTO) 
        { 
            Location location= new Location();
            location=mapper.Map<Location>(locationDTO);
          
            _context.Locations.Add(location);
            _context.SaveChanges();
            return RedirectToAction("Register","Public");
        
        }

    }
}
