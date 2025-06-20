using System.IO;
using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;

using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        IMapper mapper;
        MyDbContext _context = new MyDbContext();
        private readonly IWebHostEnvironment _env;

        public AdminController(IMapper _mapper, IWebHostEnvironment env)
        {
            mapper = _mapper;
            _env = env;
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
					return RedirectToAction("Index", "Admin", new { area = "Admin" });
					
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
                    restaurantAdmin.RestaurantAdminId=myUser.UserId;

                    _context.RestaurantAdmins.Add(restaurantAdmin);
                    _context.SaveChanges();

                    HttpContext.Session.Remove("restaurantId");

                    // ✅ redirect to GET method
                    return RedirectToAction("Login","Public", new { area = "Public" });
                }
                else
                {
                    //TempData["Message"] = "Input data is not correct";

                    // Optional: if you want to return view with the same data
                    //var locationsFromDb = _context.Locations.ToList();
                    //restaurantadmin.Locations = locationsFromDb.Select(l => new SelectListItem
                    //{
                    //    Value = l.LocationId.ToString(),
                    //    Text = l.LocationName
                    //}).ToList();

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
                string role = HttpContext.Session.GetString("Role");
                string restaurantIdStr = HttpContext.Session.GetString("restaurantId");

                if (role != Role.HotelManager.ToString())
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                var restaurantId = Guid.Parse(restaurantIdStr);




                var categoryList = Enum.GetValues(typeof(Category))
                   .Cast<Category>()
                   .Select(c => new SelectListItem
                   {
                       Value = ((int)c).ToString(),
                       Text = c.ToString()
                   }).ToList();

                //var restaurantList = _context.RestaurantProfiles
                //    .Select(r => new SelectListItem
                //    {
                //        Value = r.RestaurantId.ToString(),
                //        Text = r.RestaurantName
                //    }).ToList();

                DishDTO dishDTO = new DishDTO
                {
                    CategoryList = categoryList,
                    //RestaurantList = restaurantList
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
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dishDTO.DishImageFile.FileName)}";
                    var imagesPath = Path.Combine(_env.WebRootPath, "images");
                    // Ensure directory exists
                    if (!Directory.Exists(imagesPath))
                        Directory.CreateDirectory(imagesPath);

                    // Combine full file path
                    dish = mapper.Map<Dish>(dishDTO);
                    var filePath = Path.Combine(imagesPath, fileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        await dishDTO.DishImageFile.CopyToAsync(memoryStream);
                        dish.DishImage = memoryStream.ToArray(); // Save as byte[]
                    }
                    
                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await dishDTO.DishImageFile.CopyToAsync(stream);
                    }
                    
                  
                    dish.Availablity=DishAvailability.Available;
                    dish.ImagePath = $"images/{fileName}";




                    var restaurantId = HttpContext.Session.GetString("restaurantId");
                    dish.RestaurantId = Guid.Parse(restaurantId);
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

        [HttpGet]
        public async Task<IActionResult> ViewDish() 
        {
            var dishes = await _context.Dishes.ToListAsync();
            return View(dishes);
        }

        public FileResult GetImage(Guid id)
        {
            var dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
            if (dish != null && dish.DishImage != null)
            {
                return File(dish.DishImage, "image/jpeg"); // adjust content type if needed
            }

            // If no image exists, return default "noimage.jpg"

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/noimage.jpg");
            var imageBytes = System.IO.File.ReadAllBytes(path);
            return File(imageBytes, "image/jpeg");
        }


    }
}
