using FoodOrderingSystem.Enums;

namespace FoodOrderingSystem.Models
{
	public class Logins
	{
		public Guid Id { get; set; }
		public string username { get; set; }
		public string password { get; set; }	
		public Role Role { get; set; }
	}
}
