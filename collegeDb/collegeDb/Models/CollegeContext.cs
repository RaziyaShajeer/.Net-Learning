using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeDb.Models
{
	internal class CollegeContext:DbContext
	{
		public DbSet<student> students { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=College;Integrated Security=True;Trust Server Certificate=True");
		}
	}
}
