using OnlineFoodOrderingSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
	public class User
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }	
		public Role Role { get; set; }
		public string City { get; set; }
		[ForeignKey("Location")]
		public Guid LocationId { get;set; }
		public virtual Location Location { get; set; }
		public DateTime createdAt { get; set; } = DateTime.Now;
	}
}
