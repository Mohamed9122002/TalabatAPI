using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.ProductModel;

namespace Talabat.Persistence.Data.Configurations
{
    class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(T => T.ProductType)
                .WithMany()
                .HasForeignKey(p => p.TypeId);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");
        }
    }
}
