using FoodOrderingSystem.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);


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
app.UseSession();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Public}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    // Route for areas
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Public}/{action=Index}/{id?}");

    // Default route for root URL ("/") to go to area "Public"
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Public}/{action=Index}/{id?}",
        defaults: new { area = "Public" });
});






app.Run();
