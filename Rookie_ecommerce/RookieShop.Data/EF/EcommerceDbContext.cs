using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Entities;

namespace RookieShop.Backend.EF
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Products_Category> Products_Categories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
