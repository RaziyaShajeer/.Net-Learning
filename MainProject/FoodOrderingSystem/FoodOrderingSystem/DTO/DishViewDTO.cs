using FoodOrderingSystem.Enums;

namespace FoodOrderingSystem.DTO
{
	public class DishViewDTO
	{
		public Guid DishId { get; set; }
		public string DishName { get; set; }
		public string Description { get; set; }
		public string CategoryName { get; set; }
		public string DishImagePath { get; set; }
		public DishAvailability Availablity { get; set; }
		public string RestaurantName { get; set; }
		public decimal? Price { get; set; }

	}
}
