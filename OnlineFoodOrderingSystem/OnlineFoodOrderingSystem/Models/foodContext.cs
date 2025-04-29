using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.Models
{
	public class foodContext:DbContext
	{
		public DbSet<Dish> dishes { get; set; }
		public DbSet<Location> locations { get; set; }	
		public DbSet<Restaurant> restaurants { get; set; }
		public DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=FoodOrdering;Integrated Security=True;Trust Server Certificate=True");
		}
	}
}
