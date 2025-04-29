using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
	public class RestaurantAdmin : User
	{
		public Guid RestaurantAdminId { get; set; }
		[ForeignKey("Location")]
		public Guid RestaurantId { get; set; }
		public virtual Restaurant Restaurant
		{
			get; set;
		}
	}
}
