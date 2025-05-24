using Microsoft.EntityFrameworkCore;
using examwork.DTO;

namespace examwork.Models
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<student> students {  get; set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=examdb2;Integrated Security=True;Trust Server Certificate=True");
            }
        }
        public DbSet<examwork.DTO.UserDTO> UserDTO { get; set; } = default!;
    }
}