using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
	public class RestaurantAdmin : User
	{
		[ForeignKey("Restaurant")]
		public Guid RestaurantId { get; set; }
		public virtual Restaurant Restaurant { get; set; }
	}
}
