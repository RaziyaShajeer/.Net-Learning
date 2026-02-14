namespace FoodOrderingSystem.DTO
{
	public class EditCategoryDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; }
		public string CategoryImagePath { get; set; }
		public IFormFile CategoryImage { get; set; }
	}
}
