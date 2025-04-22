using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace schoolDb.Models
{
    class ApplicationDbContext:DbContext
    {
        public DbSet<student> students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7C5TMH;Initial Catalog=schoolDb;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
