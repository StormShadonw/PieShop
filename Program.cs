using Microsoft.EntityFrameworkCore;
using PieShop.Data.Repositories.Implementations;
using PieShop.Models;
using PieShop.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));

builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PieShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PieShopDbConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if(app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapRazorPages();

// Create system data in DB
SeedData.Seed(app);

app.Run();
