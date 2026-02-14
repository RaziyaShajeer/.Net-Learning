using FoodOrderingSystem.Enums;
using FoodOrderingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.DTO
{
    public class RestaurentProfileDTO
    {


        

        public string RestaurantName { get; set; } = null!;
        

        public RestaurantType RestauratType { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }

        public string LocationName { get; set; }

        public IFormFile RestaurantImage { get; set; }

        
        public IEnumerable<SelectListItem>? restauranttype { get; set; }




    }
}
