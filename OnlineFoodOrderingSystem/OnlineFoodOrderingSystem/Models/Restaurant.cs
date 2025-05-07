using OnlineFoodOrderingSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
	public class Restaurant
	{
	 public Guid RestaurantId { get;set; }
		public string RestaurantName { get; set; }
		public RestaurantType RestauratType { get; set; }
		public string Phone { get; set; }
		[ForeignKey("Location")]
		public Guid LocationId { get; set; }
		public Location Location { get; set; }
		public byte[] RestaurantImage { get; set; }
		public DateTime CeatedAt { get; set; }

		public virtual ICollection<RestaurantAdmin> RestaurantAdmins { get; set; }
		public Status Status { get; set; }

	}
}
