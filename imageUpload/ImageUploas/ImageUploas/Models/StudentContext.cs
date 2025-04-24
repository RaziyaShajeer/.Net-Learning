using Microsoft.EntityFrameworkCore;

namespace ImageUploas.Models
{
	public class StudentContext:DbContext
	{
		public DbSet<Student> Students { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=Students;Integrated Security=True;Trust Server Certificate=True");
		}

	}
}
