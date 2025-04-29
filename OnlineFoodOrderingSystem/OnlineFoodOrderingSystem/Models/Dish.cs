using OnlineFoodOrderingSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
	public class Dish
	{
		public Guid DishId { get; set; }
		public string Name { get; set; }	
		public string Description { get; set; }
		public RestaurantType Type { get; set; }
		public byte[] DishImage { get; set; }
		public Category category { get; set; }
		public Availablity Availablity { get;set; }
		[ForeignKey("Restaurant")]	
		
		public Guid RestaurantId { get; set; }	
		public Restaurant Restaurant { get; set; }
		public DateTime createdAt { get; set; } = DateTime.Now;


	}
}
