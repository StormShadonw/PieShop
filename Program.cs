using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PieShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PieShopDbConnection")));

var app = builder.Build();

app.UseStaticFiles();

if(app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

// Create system data in DB
SeedData.Seed(app);

app.Run();
