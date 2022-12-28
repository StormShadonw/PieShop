using Microsoft.EntityFrameworkCore;
using PieShop.Data.Repositories.Implementations;
using PieShop.Models;
using PieShop.Repositories.Interfaces;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));

builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddServerSideBlazor();

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<PieShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PieShopDbConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<PieShopDbContext>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

if(app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapRazorPages();

app.MapBlazorHub();

app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

// Create system data in DB
SeedData.Seed(app);

app.Run();
