using FoodOrderingSystem.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.DTO
{
	public class EditViewDishDTO
	{
		public Guid DishId { get; set; }
		public string DishName { get; set; }
		public string Description { get; set; }
		public Guid CategoryId { get; set; }
		public DishType DishType { get; set; }
		public string CategoryName { get; set; }
		public string DishImagePath { get; set; }
		public DishAvailability Availablity { get; set; }
		public string RestaurantName { get; set; }
		public decimal Price { get; set; }
		public IFormFile Image { get; set; }
		public IEnumerable<SelectListItem>? availablityList { get; set; }
		public IEnumerable<SelectListItem>? DishtypeList { get; set; }
	}
}
