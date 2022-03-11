using Microsoft.EntityFrameworkCore;
using Rookie.CustomerSite.Service;
using Rookie_ecommerce.Application.Common;
using RookieShop.Data.EF;
using RookieShop.Utilities.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<EcommerceDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategorySevice, CategoryService>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();