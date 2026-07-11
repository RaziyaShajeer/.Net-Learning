using FoodOrderingSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodOrderingSystem.DTO
{
	public class OrderedItemsDto	
	{
		public List<Cartitem> cartitems { get; set; }
		public IEnumerable<SelectListItem>? PaymentmodeList { get; set; }
	}
}
