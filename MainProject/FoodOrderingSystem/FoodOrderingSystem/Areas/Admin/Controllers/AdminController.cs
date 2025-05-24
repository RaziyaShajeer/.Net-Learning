using System.IO;
using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Migrations;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        IMapper mapper;
        MyDbContext _context;

        public AdminController(IMapper _mapper,MyDbContext _Context)
        {
            _context = _Context;

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
            try
            {
                if (ModelState.IsValid)
                {
                    Location location = mapper.Map<Location>(locationDTO);

                    _context.Locations.Add(location);
                    _context.SaveChanges();

                    return RedirectToAction("Register", "Public", new { area = "Public" });
                }
                else
                {
                    ViewData["Message"] = "Please fill all required fields.";
                    return View(locationDTO);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult ViewUsers()
        {
            var users = _context.MyUsers
                .Where(u => u.Role == Enums.Role.User)
                .ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            var restaurantTypeList = Enum.GetValues(typeof(RestaurantType))
        .Cast<RestaurantType>()
        .Select(g => new SelectListItem
        {
            Value = ((int)g).ToString(),
            Text = g.ToString()
        }).ToList();

            RestaurentProfileDTO restaurentProfileDTO = new RestaurentProfileDTO(); 
            restaurentProfileDTO.restauranttype = restaurantTypeList;

          

            return View(restaurentProfileDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(RestaurentProfileDTO restaurantProfileDTO)
        {
            try

            {
                if (ModelState.IsValid)
                {
            
                RestaurantProfile restaurantprofile = new RestaurantProfile();
                restaurantprofile = mapper.Map<RestaurantProfile>(restaurantProfileDTO);
                if (restaurantProfileDTO.RestaurantImage != null && restaurantProfileDTO.RestaurantImage.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(restaurantProfileDTO.RestaurantImage.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await restaurantProfileDTO.RestaurantImage.CopyToAsync(fileStream);
                        }
                        using (var memoryStream = new MemoryStream())
                    {
                        await restaurantProfileDTO.RestaurantImage.CopyToAsync(memoryStream);
                        restaurantprofile.RestaurantImages = memoryStream.ToArray(); // Save as byte[]
                    }

                  
                }
                restaurantprofile.Status=RestaurantStatus.Active;
                    var exist = _context.RestaurantProfiles.Where(e => e.RestaurantName == restaurantprofile.RestaurantName).FirstOrDefault();
                    if(exist!=null)
                    {
                        TempData["Message"] = "Already exist Name.";

                        return RedirectToAction("AddRestaurant");
                    }
                // Save to DB (assuming you have a context)
                _context.RestaurantProfiles.Add(restaurantprofile);
                await _context.SaveChangesAsync();
                    HttpContext.Session.SetString("restaurantId", restaurantprofile.RestaurantId.ToString());


                    //_context.RestaurantProfiles.Add(restaurantProfile);
                    //_context.SaveChanges();

                    return RedirectToAction("registerRestaurantAdmin");
                }
                else
                {
                    TempData["Message"] = "Please provide valid restaurant details.";
                    return View(restaurantProfileDTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return RedirectToAction("registerRestaurantAdmin");
            }
        }


        [HttpGet]
        public IActionResult registerRestaurantAdmin()
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
        public IActionResult registerRestaurantAdmin(UserDTO restaurantadmin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MyUser myUser = mapper.Map<MyUser>(restaurantadmin);
                    myUser.Role = Role.HotelManager;

                    _context.MyUsers.Add(myUser);
                    _context.SaveChanges();

                    var restaurantId = Guid.Parse(HttpContext.Session.GetString("restaurantId"));
                    RestaurantAdmin restaurantAdmin = new RestaurantAdmin
                    {
                        RestaurantId = restaurantId
                    };
                    restaurantAdmin.RestaurantAdminId = restaurantadmin.UserId;
                    _context.RestaurantAdmins.Add(restaurantAdmin);
                    _context.SaveChanges();

                    HttpContext.Session.Remove("restaurantId");

                    // ✅ redirect to GET method
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Input data is not correct";

                    // Optional: if you want to return view with the same data
                 
                    return View(restaurantadmin);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpGet]
        public IActionResult AddDish()
        {
            try
            {
                var categoryList = Enum.GetValues(typeof(Category))
                   .Cast<Category>()
                   .Select(c => new SelectListItem
                   {
                       Value = ((int)c).ToString(),
                       Text = c.ToString()
                   }).ToList();

              

                DishDTO dishDTO = new DishDTO
                {
                    CategoryList = categoryList,
                    
                };



                return View(dishDTO);
            }
            catch (Exception)
            {
               
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddDish(DishDTO dishDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dish dish = new Dish();
                    dish = mapper.Map<Dish>(dishDTO);
                    dish.Availablity=DishAvailability.Available;

                    if (dishDTO.DishImageFile != null && dishDTO.DishImageFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dishDTO.DishImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await dishDTO.DishImageFile.CopyToAsync(fileStream);
                        }

                        using (var memoryStream = new MemoryStream())
                        {
                            await dishDTO.DishImageFile.CopyToAsync(memoryStream);
                            dish.DishImage = memoryStream.ToArray(); // Save as byte[]
                        }
                    }
					dish.RestaurantId = Guid.Parse("8BDE61DE-8F43-40C0-A96A-18019E153E90");
					_context.Dishes.Add(dish);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Dish added successfully.";
                    return RedirectToAction("AddDish");
                }
                else
                {
                    TempData["Message"] = "Please provide valid dish details.";


                    

                    

                    return View(dishDTO);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }




    }
}
