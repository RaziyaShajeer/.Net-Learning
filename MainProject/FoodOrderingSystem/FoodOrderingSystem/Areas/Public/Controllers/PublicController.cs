using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.Areas.Public.Controllers
{
    [Area("Public")]
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
            try
            {
                return View("~/Areas/Public/Views/Public/Index.cshtml");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            try
            {
                //var locationsFromDb = _context.Locations.ToList();
                //var userDTO = new UserDTO
                //{
                //    Locations = locationsFromDb.Select(l => new SelectListItem
                //    {
                //        Value = l.LocationId.ToString(),
                //        Text = l.LocationName
                //    }).ToList()
                //};

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    MyUser myUser = new MyUser();

                    myUser = mapper.Map<MyUser>(userDTO);
                    myUser.Role = Role.User;
                    //myUser.LocationId = new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301");


                    _context.MyUsers.Add(myUser);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Public");
                }
                else
                {
                    TempData["Messgae"] = "Input data is not correct";
                    return View(userDTO);
;                }
               
            }
            catch (Exception ex) {
                return RedirectToAction("Error","Home");
            }
           
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(string Email, string password)
        {
            try
            {
                var user = _context.MyUsers.Where(u => u.Email == Email && u.Password == password).FirstOrDefault();

                if (user != null)
                {
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("Role", user.Role.ToString());
                    if (user.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid login";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

    

