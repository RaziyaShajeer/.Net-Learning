using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FoodOrderingSystem.Controllers
{
    public class PublicController : Controller
    {
        IMapper mapper;
        MyDbContext _context = new MyDbContext();

        public PublicController(IMapper _mapper)
        {
           mapper = _mapper; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            MyUser myUser = new MyUser();

            myUser=mapper.Map<MyUser>(userDTO);
            myUser.Role = Role.User;
            myUser.LocationId = new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301");

            _context.MyUsers.Add(myUser);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string Email,string password)
        //{
        //    _context.MyUsers.
        //    _context.SaveChanges();
        //    return View();
        //}
    }
}
