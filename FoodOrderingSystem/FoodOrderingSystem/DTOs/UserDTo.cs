using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderingSystem.DTOs
{
	public class UserDTo
	{
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string State { get; set; }
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please select a location")]
		public Guid LocationId { get; set; }

		public IEnumerable<SelectListItem> Locations { get; set; }
	}
}
