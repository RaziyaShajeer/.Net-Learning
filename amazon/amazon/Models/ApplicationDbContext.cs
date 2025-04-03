using Microsoft.EntityFrameworkCore;

namespace amazon.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=amazondb;Integrated Security=True;Trust Server Certificate=True");
            }
        }
    }
}
