using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace exammodel.Models
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<teacher> teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=examdb;Integrated Security=True;Trust Server Certificate=True");
            }
        }
    }
}
