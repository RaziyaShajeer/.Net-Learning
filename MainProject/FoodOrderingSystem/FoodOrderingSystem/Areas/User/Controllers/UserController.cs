using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Areas.User.Controllers
{
	[Area("User")]
	public class UserController : Controller
	{
		MyDbContext _context = new MyDbContext();
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ViewAllDishes()
		{
		var alldishes = _context.Dishes.ToList();
			return View(alldishes);
		}
		public async Task<IActionResult> ViewRestaurants()
		{
			var allrestaurants =await  _context.RestaurantProfiles.ToListAsync();
			return View(allrestaurants);
		}

	}
}
