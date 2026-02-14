using System.IO;
using System.Numerics;
using System.Text.Json;
using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Enums;
//using FoodOrderingSystem.Migrations;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Services;
using Humanizer;
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
		private readonly EmailService _emailService;
		public AdminController(IMapper _mapper, IWebHostEnvironment env,EmailService emailService)
        {
            mapper = _mapper;
            _env = env;
			_emailService = emailService;
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
                    var fileName = "";
                    if (restaurantProfileDTO.RestaurantImage != null && restaurantProfileDTO.RestaurantImage.Length > 0)
                    {

						 fileName = $"{Guid.NewGuid()}{Path.GetExtension(restaurantProfileDTO.RestaurantImage.FileName)}";
						var imagesPath = Path.Combine(_env.WebRootPath, "uploads");

						if (!Directory.Exists(imagesPath))
							Directory.CreateDirectory(imagesPath);

						var filePath = Path.Combine(imagesPath, fileName);
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await restaurantProfileDTO.RestaurantImage.CopyToAsync(stream);
						}


					}
                    restaurantprofile.Status = RestaurantStatus.Active;
                    restaurantprofile.Restaurantimage= $"uploads/{fileName}";
					var exist = _context.RestaurantProfiles.Where(e => e.RestaurantName == restaurantprofile.RestaurantName && e.UserName==restaurantprofile.UserName).FirstOrDefault();
                    if (exist != null)
                    {
                        TempData["Message"] = "Already exist Name.";

                        return RedirectToAction("AddRestaurant");
                    }
                    // Save to DB (assuming you have a context)
                    _context.RestaurantProfiles.Add(restaurantprofile);
                    await _context.SaveChangesAsync();


                    await _emailService.SendEmailAsync(restaurantprofile.RestaurantName, restaurantprofile.UserName, restaurantprofile.Password);
                    
                    var login = new Logins();
                    login.Id=restaurantprofile.RestaurantId;
                    login.Role = Role.HotelManager;
                    login.username = restaurantprofile.UserName;    
                    login.password=restaurantprofile.Password;
                   var logins=await _context.Logins.Where(e=>e.username==login.username).FirstOrDefaultAsync();
                    if (logins == null)
                    {
                        await _context.Logins.AddRangeAsync(login);

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
						TempData["Message"] = "Already exist Name.";

						return RedirectToAction("AddRestaurant");
					}


					//_context.RestaurantProfiles.Add(restaurantProfile);
					//_context.SaveChanges();

					return RedirectToAction("Login", "Public", new { area = "Public" });
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
                // var locationsFromDb = _context.Locations.ToList();
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

                    _context.RestaurantAdmins.Add(restaurantAdmin);
                    _context.SaveChanges();

                    HttpContext.Session.Remove("restaurantId");

                    // ✅ redirect to GET method
                    return RedirectToAction("AddRestaurant");
                }
                else
                {
                    TempData["Message"] = "Input data is not correct";



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
				var categoryList = _context.Category
		   .Select(c => new SelectListItem
		   {
			   Value = c.Id.ToString(),
			   Text = c.CategoryName
		   })
		   .ToList();

				ViewBag.Categories = categoryList;  // Now it's List<SelectListItem>

				var DishtypeList = Enum.GetValues(typeof(DishType))
			.Cast<DishType>()
			.Select(g => new SelectListItem
			{
				Value = ((int)g).ToString(),
				Text = g.ToString(),
				 

			}).ToList();
				ViewBag.dishtype = DishtypeList;  
				return View();
				
				
                   
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }
     
        public IActionResult DeleteDish(Guid Id)
        {
            var dish = _context.Dishes.Where(e => e.DishId == Id).FirstOrDefault();
            if(dish!=null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewAllDishes", "Admin");
        }
		[HttpGet]
		public IActionResult ViewAllDishes(Guid? restaurantId)
        {
			//Guid restaurantId =Guid.Parse( HttpContext.Session.GetString("restaurantId"));
			string restaurantIdStr = HttpContext.Session.GetString("restaurantId");
            
			var dishesQuery = _context.Dishes
.Include(d => d.Restaurant)
.Include(d => d.category)
.AsQueryable();
		
        if (restaurantId.HasValue)
    {
        dishesQuery = dishesQuery.Where(d => d.Restaurant.RestaurantId == restaurantId);
    }
            if (!string.IsNullOrEmpty(restaurantIdStr))
			{
				// Display all dishes
				dishesQuery = dishesQuery.Where(d => d.Restaurant.RestaurantId == Guid.Parse(restaurantIdStr));
			}
         
			var restaurants = _context.RestaurantProfiles.ToList();

			var vm = new DishListViewModel
			{
				DishList = mapper.Map<List<DishViewDTO>>(dishesQuery.ToList()),
				Restaurants = _context.RestaurantProfiles.ToList()
			};
			return View(vm);
        }


		[HttpPost]
        public async Task<IActionResult> AddDish(DishDTO dishDTO)
        {
            try
            {
				Dish dish = new Dish();
				if (ModelState.IsValid)
                {
                 

					var fileName = "";
					if (dishDTO.DishImageFile != null && dishDTO.DishImageFile.Length > 0)
					{

						fileName = $"{Guid.NewGuid()}{Path.GetExtension(dishDTO.DishImageFile.FileName)}";
						var imagesPath = Path.Combine(_env.WebRootPath, "uploads");

						if (!Directory.Exists(imagesPath))
							Directory.CreateDirectory(imagesPath);

						var filePath = Path.Combine(imagesPath, fileName);
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await dishDTO.DishImageFile.CopyToAsync(stream);
						}
						
                       
						dish = mapper.Map<Dish>(dishDTO);
						dish.DishImagePath = $"uploads/{fileName}";
						dish.Availablity = DishAvailability.Available;

					}
					string restaurantId = HttpContext.Session.GetString("restaurantId");
					if (restaurantId != null)
					{
						// Use the value
						Guid restaurantIdGuid = Guid.Parse(restaurantId);
                        dish.RestaurantId = restaurantIdGuid;
					}
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
        public IActionResult AddCategory()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(categoryDto.CategoryImage.FileName)}";
            var imagesPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);

            var filePath = Path.Combine(imagesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await categoryDto.CategoryImage.CopyToAsync(stream);
            }

            var category = mapper.Map<Models.Category>(categoryDto);
            category.CategoryImagePath = $"uploads/{fileName}";
            _context.Category.AddAsync(category);
            _context.SaveChangesAsync();
            return RedirectToAction("GellAllCategory");
        }
        [HttpGet]
        public async Task<IActionResult> GellAllCategory()
        {
            var list = await _context.Category.ToListAsync();
            return View(list);

        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(Guid Id)
        {
            var category = await _context.Category.Where(e => e.Id == Id).FirstOrDefaultAsync();
			ModelState.Clear(); // Ensure textboxes take values from model
            var categoryToedit = mapper.Map<EditCategoryDto>(category);
			return View(categoryToedit);
		}
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryDto categorydto)
        {

            var category = new Models.Category();
			category = mapper.Map<Models.Category>(categorydto);
			if (categorydto.CategoryImage!=null)
            {
				var fileName = $"{Guid.NewGuid()}{Path.GetExtension(categorydto.CategoryImage.FileName)}";
				var imagesPath = Path.Combine(_env.WebRootPath, "uploads");

				if (!Directory.Exists(imagesPath))
					Directory.CreateDirectory(imagesPath);

				var filePath = Path.Combine(imagesPath, fileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await categorydto.CategoryImage.CopyToAsync(stream);
				}
				
				category.CategoryImagePath = $"uploads/{fileName}";

			}
            var categoryToUpdate=_context.Category.Where(e=>e.Id==categorydto.Id).FirstOrDefault();
           categoryToUpdate.CategoryName= category.CategoryName!=null?category.CategoryName:categoryToUpdate.CategoryName;
            categoryToUpdate.CategoryImagePath = category.CategoryImagePath != null? category.CategoryImagePath:categoryToUpdate.CategoryImagePath;    
           _context.Category.Update(categoryToUpdate);  
           _context.SaveChanges();  
            return RedirectToAction("GellAllCategory");

		}
		public async Task<IActionResult> deleteCategory(Guid Id)
        {
            var categorytoDelete = _context.Category.Where(e => e.Id == Id).FirstOrDefault();
            _context.Category.Remove(categorytoDelete);
            _context.SaveChanges();
            return RedirectToAction("GellAllCategory");
        }
        [HttpGet]
		public async Task<IActionResult> EditDish(Guid Id)
		{
			var DishtoUpdate = _context.Dishes.Where(e => e.DishId == Id).Include(e=>e.Restaurant).FirstOrDefault();
            var DishtoUpdateDTO = mapper.Map<EditViewDishDTO>(DishtoUpdate);

            var categories = _context.Category.ToList();
			
		
			var categoryList = _context.Category
		   .Select(c => new SelectListItem
		   {
			   Value = c.Id.ToString(),
			   Text = c.CategoryName,

			   Selected = (c.Id == DishtoUpdateDTO.CategoryId)  // ✅ mark the selected one
		   })
		   .ToList();

			ViewBag.Categories = categoryList;
			var AvailablityList = Enum.GetValues(typeof(DishAvailability))
			.Cast<DishAvailability>()
			.Select(g => new SelectListItem
			{
				Value = ((int)g).ToString(),
				Text = g.ToString(),
				Selected =g == DishtoUpdateDTO.Availablity // ✅ Mark the matching one as selected

			}).ToList();
			var dishtype = Enum.GetValues(typeof(DishType))
			.Cast<DishType>()
			.Select(g => new SelectListItem
			{
				Value = ((int)g).ToString(),
				Text = g.ToString(),
				Selected = g == DishtoUpdateDTO.DishType // ✅ Mark the matching one as selected

			}).ToList();

			DishtoUpdateDTO.availablityList = AvailablityList;

			DishtoUpdateDTO.DishtypeList=dishtype;

			return View(DishtoUpdateDTO);
			
		}

	
    [HttpPost]
		public async Task<IActionResult> EditDish(EditViewDishDTO editViewDishDTO,Guid id)
		{
            var dishtoUpdate= _context.Dishes.Where(e => e.DishId == editViewDishDTO.DishId).Include(e => e.Restaurant).FirstOrDefault();
		
				var fileName = "";
				if (editViewDishDTO.Image != null && editViewDishDTO.Image.Length > 0)
				{
				fileName = $"{Guid.NewGuid()}{Path.GetExtension(editViewDishDTO.Image.FileName)}";
				var imagesPath = Path.Combine(_env.WebRootPath, "uploads");

				if (!Directory.Exists(imagesPath))
					Directory.CreateDirectory(imagesPath);

				var filePath = Path.Combine(imagesPath, fileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await editViewDishDTO.Image.CopyToAsync(stream);
				}
				dishtoUpdate.DishImagePath = $"uploads/{fileName}";
			}

               
            dishtoUpdate.DishName = editViewDishDTO.DishName;
            dishtoUpdate.Price = editViewDishDTO.Price;
            dishtoUpdate.Availablity = editViewDishDTO.Availablity;
			dishtoUpdate.dishType=editViewDishDTO.DishType;
            _context.Dishes.Update(dishtoUpdate);
            _context.SaveChanges(); 

			//var DishtoUpdateDTO = mapper.Map<EditViewDishDTO>(DishtoUpdate);

		
		

		
			return RedirectToAction("ViewAllDishes","Admin");
		}

	}
}
