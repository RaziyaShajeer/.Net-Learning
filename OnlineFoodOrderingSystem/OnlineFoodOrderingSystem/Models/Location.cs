namespace OnlineFoodOrderingSystem.Models
{
	public class Location
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Restaurant> Restaurants { get; set; }
	}
}
