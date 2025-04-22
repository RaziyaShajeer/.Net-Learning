using Microsoft.EntityFrameworkCore;

namespace exam.Models
{
    public class ApplicationDbContext:DbContext
    {
        
        DbSet<Student> Students {  get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=mydb;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
