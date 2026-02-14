using AutoMapper;
using FoodOrderingSystem.Areas.User.Data;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DishDTO = FoodOrderingSystem.Areas.User.Data.DishDTO;

namespace FoodOrderingSystem.Areas.User.Controllers
{
	[Area("User")]
	public class UserController : Controller
	{
		MyDbContext context = new MyDbContext();
		IMapper _mapper;
		public UserController(IMapper mapper)
		{
			_mapper = mapper;

		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ViewItem(Guid itemId)
		{
			var dish = context.Dishes
				.Include(e => e.category)
				.FirstOrDefault(e => e.DishId == itemId);

			if (dish == null)
			{
				return NotFound(); // or redirect to error page
			}

			var dishDto = _mapper.Map<DishDTO>(dish);

			return View(dishDto);
		}
		[HttpPost]

		public IActionResult AddToCart([FromBody] AddToCartDto model)
		{
			var dishId = model.DishId;
			var quantity = model.Quantity;
			var userId = HttpContext.Session.GetString("UserId");

			if (string.IsNullOrEmpty(userId))
				return Unauthorized();

			var userGuid = Guid.Parse(userId);

			var cart = context.Carts
				.Include(c => c.CartItems)
				.FirstOrDefault(c => c.UserId == userGuid);

			if (cart == null)
			{
				cart = new Cart
				{
					CartId = Guid.NewGuid(),
					UserId = userGuid,
					CreatedAt = DateTime.Now
				};

				context.Carts.Add(cart);
				context.SaveChanges();
			}

			var existingItem = cart.CartItems
				.FirstOrDefault(ci => ci.DishId == dishId);
			var dish = context.Dishes.Where(e => e.DishId == dishId).FirstOrDefault();
			if (existingItem != null)
			{
				existingItem.Quanity += quantity;
				existingItem.Total = existingItem.Quanity * dish.Price;
			}
			else
			{
				

				var cartitem = new Cartitem
				{
					CartItemId = Guid.NewGuid(),
					cartId = cart.CartId,   // ✅ correct FK
					DishId = dishId,
					Price = dish.Price,
					Total=quantity*dish.Price,
					Quanity = quantity

				};


				context.Cartitems.Add(cartitem);
			}

			context.SaveChanges();
			return Ok();
		}
	}

	
}
