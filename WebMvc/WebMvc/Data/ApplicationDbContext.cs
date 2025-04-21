using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebMvc.Areas.Admin.Controllers;
using WebMvc.Models.ViewModels;

namespace WebMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>Options)
            : base(Options)

        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<ProductController>().;

        //}

        public DbSet<WebMvc.Models.ViewModels.LoginViewModel> LoginViewModel { get;set;} = default!;
        public DbSet<WebMvc.Models.ViewModels.RegisterViewModel> RegisterViewModel { get;set;} = default!;
        public DbSet<WebMvc.Models.catagoryModel> catagoryModel { get; set; } = default!;
        public DbSet<WebMvc.Models.ProductModel> ProductModel { get; set; } = default!;
    }
}
