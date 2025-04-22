using Microsoft.EntityFrameworkCore;

namespace Examination.Models
{
    public class ApplicationDbContext:DbContext
    {
        DbSet<student> students {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=newdb;Integrated Security=True;Trust Server Certificate=True");

        }
    }
}

