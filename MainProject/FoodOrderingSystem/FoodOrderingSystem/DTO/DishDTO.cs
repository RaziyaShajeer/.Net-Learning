using FoodOrderingSystem.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.DTO
{
    public class DishDTO
    {

        public string DishName { get; set; } = null!;

        public string Description { get; set; } = null!;
        [NotMapped]
        public IFormFile? DishImageFile { get; set; }

        public Category Category { get; set; }

      

        public decimal Price { get; set; }

        public Guid? RestaurantId { get; set; }

        public IEnumerable<SelectListItem>? CategoryList { get; set; }

        
    }
}

