using Microsoft.EntityFrameworkCore;
using RookieShop.Data.EF;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using RookieShop.Utilities.Constants;
using Rookie_ecommerce.Application.Catalog.Products;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json")
    .Build();
//var connectionString = configuration.GetConnectionString(SystemConstants.MainConnectionString);
builder.Services.AddDbContext<EcommerceDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString(SystemConstants.MainConnectionString)));
builder.Services.AddTransient<IPublicProductService, PublicProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eCommerce Rookie", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger eCommerce Rookie V1");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();