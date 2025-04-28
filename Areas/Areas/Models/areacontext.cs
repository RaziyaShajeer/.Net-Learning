using Areas.Areas.Blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace Areas.Models
{
	public class areacontext:DbContext
	{
		public DbSet<Student> students { get;set; }
		public DbSet<Scool> school { get;set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=Areardb;Integrated Security=True;Trust Server Certificate=True");
		}
	}
}
