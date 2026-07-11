namespace FoodOrderingSystem.Areas.User.Data
{
	public class DishDTO
	{
		public Guid DishId { get; set; } 
		public string DishName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string CategoryName { get; set; }
		public string DishImagePath { get; set; }
		public decimal Price { get; set; }

	}
}
