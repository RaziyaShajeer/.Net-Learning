using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
				var locationsFromDb = _context.Locations
	   .Select(c => new SelectListItem
	   {
		   Value = c.LocationId.ToString(),
		   Text = c.LocationName
	   })
	   .ToList();
				ViewBag.LocationList = locationsFromDb;

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
                    Logins logins = new Logins();
                    logins.username = myUser.Email;
                    logins.password = myUser.Password;
                    logins.Role = Role.User;
                    logins.password = myUser.Password;
                    var result = _context.Logins.Where(e => e.username == logins.username).Any();
                    if (result)
                    {
						TempData["Messgae"] = "already Registered Customer";
                        return RedirectToAction("Register", myUser);
					}
                    else
                    {
                        _context.Logins.Add(logins);
                        _context.SaveChanges();
                       
                    }
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
        public async Task<IActionResult> Login(string Email, string password)
        {
            try
            {
                var user = _context.MyUsers.Where(u => u.Email == Email && u.Password == password).FirstOrDefault();
                
                if (user != null)
                {
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("Role", user.Role.ToString());
                    if (user.Role == Role.HotelManager)
                    {
                       var restaurant= await _context.RestaurantProfiles.Where(e=>e.RestaurantId == user.UserId).FirstOrDefaultAsync();   
                     if(restaurant!=null)
                        {
							return RedirectToAction("ViewRestaurant", "Public", new { id = restaurant.RestaurantId });
						}
                        else
                        {
							return RedirectToAction("ViewAllDishes", "Admin");
						}
                        
                    }
                    else
                    {

						return RedirectToAction("ViewAllDishes","Admin",new { area = "Admin" });

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
        [HttpGet]
		public IActionResult Logout()
		{
			// Clear all session values
			HttpContext.Session.Clear();

			// Optional: explicitly remove keys
			// HttpContext.Session.Remove("UserId");
			// HttpContext.Session.Remove("Role");

			return RedirectToAction("Index");
		}
		[HttpGet]
        public async Task<IActionResult> ViewRestaurant(Guid Id)
        {
            var restaurant = await _context.RestaurantProfiles.Where(e => e.RestaurantId == Id).FirstOrDefaultAsync();
			HttpContext.Session.SetString("restaurantId", restaurant.RestaurantId.ToString());
			return View(restaurant);
        }
    }
}

    

