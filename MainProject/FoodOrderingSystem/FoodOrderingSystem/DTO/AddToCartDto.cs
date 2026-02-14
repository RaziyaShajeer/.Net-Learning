namespace FoodOrderingSystem.DTO
{
	public class AddToCartDto
	{
		public Guid DishId { get; set; }
		public int Quantity { get; set; }
	}
}
