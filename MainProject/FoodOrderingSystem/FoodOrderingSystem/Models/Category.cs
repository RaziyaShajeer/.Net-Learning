namespace FoodOrderingSystem.Models
{
	public class Category
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string CategoryName { get; set; }
		public string CategoryImagePath { get; set; }	
	}
}
