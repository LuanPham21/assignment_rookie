using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RookieShop.Data.Entities;
using RookieShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    ParentId = null,
                    Name = "Bánh kem",
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    ParentId = null,
                    Name = "Bánh socola",
                    Status = Status.Active,
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() 
                {
                    Id = 1,
                    Name="Bánh kem vị dâu",
                    Quantity =100,
                    OriginalPrice =10000,
                    Price =20000,
                    Description = "Bánh kem được làm từ dâu tự nhiên",
                    TimeCreate = DateTime.Now,
                    Status = Status.Active,
                    ViewCount = 1,
                    Details = "Bánh kem được làm từ dâu tự nhiên"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Bánh socola",
                    Quantity = 100,
                    OriginalPrice = 10000,
                    Price = 20000,
                    Description = "Bánh socola được làm từ socola trắng với hạnh nhân",
                    TimeCreate = DateTime.Now,
                    Status = Status.Active,
                    ViewCount = 1,
                    Details = "Bánh socola được làm từ socola trắng với hạnh nhân"
                }
                );
            modelBuilder.Entity<ProductsInCategory>().HasData(
                new ProductsInCategory()
                {
                    CategoryId = 1,
                    ProductId = 1
                },
                new ProductsInCategory()
                {
                    CategoryId = 2,
                    ProductId = 2
                });
            var Role_ID = new Guid("84C8304C-C52A-42BF-A985-36FB0B00743B");
            var User_ID = new Guid("5A33F896-2359-44FF-82FD-B6D33786AC2A");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = Role_ID,
                Name ="admin",
                NormalizedName = "admin",
                Description = "Adminstrator role"
            });
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = User_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "luanhuu2000@gmail.com",
                NormalizedEmail = "luanhuu2000@gmail.com",
                EmailConfirmed = true,
                PasswordHash =hasher.HashPassword(null,"123456"),
                SecurityStamp = string.Empty,
                FirstName = "Luan",
                LastName = "Pham",
                Dob = new DateTime(2022,02,22)
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = Role_ID,
                UserId = User_ID,
            });
        }
    }
}
