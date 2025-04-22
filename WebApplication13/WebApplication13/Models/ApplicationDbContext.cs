using Microsoft.EntityFrameworkCore;

namespace WebApplication13.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VSIB1IR;Initial Catalog=webdb13;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
