using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.DTO
{
	public class CategoryDTO
	{
		[Key]
		public Guid CategoryId { get; set; }	
		public string Name { get; set; }
		[NotMapped]
		public IFormFile CategoryImage { get; set; }
	}
}
