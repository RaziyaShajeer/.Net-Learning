using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Areas.User.Controllers
{
	[Area("User")]
	public class CartController : Controller
	{
		MyDbContext db = new MyDbContext();
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ViewCart()
		{
			var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
			var cart = db.Carts.Where(e => e.UserId == userId).FirstOrDefault();
			var CartItems = db.Cartitems.Where(e => e.cartId == cart.CartId).Include(e => e.Dish).ToList();
			return View(CartItems);


		}
		[HttpPost]
		public IActionResult UpdateQuantity(Guid id, string actionType)
		{
			var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
			var cart = db.Carts.Where(e => e.UserId == userId).FirstOrDefault();
			var cartItem = db.Cartitems
	.Include(c => c.Cart)
	.FirstOrDefault(c => c.CartItemId == id && c.cartId == cart.CartId);

			if (cartItem == null)
				return Json(new { success = false });

			if (actionType == "increase")
				cartItem.Quanity += 1;

			else if (actionType == "decrease")
			{
				cartItem.Quanity -= 1;

				if (cartItem.Quanity <= 0)
				{
					db.Cartitems.Remove(cartItem);
					db.SaveChanges();

					return Json(new { removed = true });
				}
			}

			cartItem.Total = cartItem.Price * cartItem.Quanity;

			db.SaveChanges();

			var grandTotal = db.Cartitems
							.Where(c => c.cartId == cartItem.cartId)
							.Sum(c => c.Total);

			return Json(new
			{
				success = true,
				quantity = cartItem.Quanity,
				total = cartItem.Total,
				grandTotal = grandTotal
			});
		}
		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
			var cart = db.Carts.Where(e => e.UserId == userId).FirstOrDefault();
			var cartItem = db.Cartitems.FirstOrDefault(c => c.CartItemId == id && c.cartId == cart.CartId);

			if (cartItem == null)
				return Json(new { success = false });

			db.Cartitems.Remove(cartItem);
			db.SaveChanges();

			return Json(new { success = true });
		}


		[HttpGet]
		public IActionResult Checkout()
		{
			var userIdString = HttpContext.Session.GetString("UserId");
			var paymentmodeList = Enum.GetValues(typeof(PaymentMode))
		.Cast<PaymentMode>()
		.Select(g => new SelectListItem
		{
			Value = ((int)g).ToString(),
			Text = g.ToString(),


		}).ToList();
			if (string.IsNullOrEmpty(userIdString))
				return RedirectToAction("Login", "Account");

			var userId = Guid.Parse(userIdString);

			var cart = db.Carts.FirstOrDefault(e => e.UserId == userId);


			if (cart == null)
				return View(new List<Cartitem>());

			var cartItems = db.Cartitems
				.Include(c => c.Dish)
				.Where(c => c.cartId == cart.CartId)
				.ToList();

var 
			return View(cartItems);
		}
	}
}

