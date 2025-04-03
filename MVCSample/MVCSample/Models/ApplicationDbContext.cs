using Microsoft.EntityFrameworkCore;

namespace MVCSample.Models
{
    public class ApplicationDbContext:DbContext
    {
       public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=MVCSampleDB;Integrated Security=True;Trust Server Certificate=True");
        }
    }
    }
}
