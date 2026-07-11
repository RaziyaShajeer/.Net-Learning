using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingSystem.DTO
{
    public class DishDTO
    {
                public string DishName { get; set; } = null!;

        public string Description { get; set; } = null!;
        [NotMapped]
        public IFormFile DishImageFile { get; set; }
       
        public Guid CategoryId { get; set; }

 

        public decimal? Price { get; set; }

        public Guid RestaurantId { get; set; }
		public DishType DishType { get; set; }	
		public IEnumerable<SelectListItem>? dishTypelist { get; set; }

		public IEnumerable<SelectListItem>? categoryList { get; set; }







		public DishAvailability Availablity { get; set; }

		

		
		
	}
}

