using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Data.Entities;
using RookieShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.OriginalPrice).IsRequired();
            builder.Property(x => x.Quantity).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.TimeCreate);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}