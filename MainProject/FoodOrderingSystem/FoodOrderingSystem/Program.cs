using FoodOrderingSystem.Extensions;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddSession();
builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
builder.Services.AddTransient<EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{

	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Public}/{action=Index}/{id?}");


	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Public}/{action=Index}/{id?}");
});


app.Run();
