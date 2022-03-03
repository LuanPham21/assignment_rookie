using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Data.Configurations
{
    internal class ProductsInCategoryConfiguration : IEntityTypeConfiguration<ProductsInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsInCategory> builder)
        {
            builder.ToTable("ProductsInCategories");
            builder.HasKey(x => new { x.ProductId, x.CategoryId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductsInCategories).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductsInCategories).HasForeignKey(x => x.CategoryId);
        }
    }
}