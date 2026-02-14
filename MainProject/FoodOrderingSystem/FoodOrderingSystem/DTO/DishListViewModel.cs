using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.DTO
{
	public class DishListViewModel
	{
		public List<DishViewDTO> DishList { get; set; }
		public List<RestaurantProfile> Restaurants { get; set; }
	}
}
