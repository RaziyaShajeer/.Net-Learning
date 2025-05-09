using AutoMapper;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var locations=_context.Locations.ToList();
            
			var userDTO = new UserDTo
			{
				Locations = locations.Select(l => new SelectListItem
				{
					Value = l.LocationId.ToString(),
					Text = l.LocationName
				}).ToList()
			};

			return View(userDTO);
		}


        [HttpPost]
        public IActionResult Register(UserDTo userDTO)
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

        [HttpPost]
        public IActionResult Login(string Email, string password)
        {
            var User=_context.MyUsers.Where(e=>e.Email==Email && e.Password==password).ToList();
            if (User.Any())
            {

                return View();
            }
            else
            {
                ViewData["Message"] = "Login Failed";
                return View();
            }
        }
    }
}
