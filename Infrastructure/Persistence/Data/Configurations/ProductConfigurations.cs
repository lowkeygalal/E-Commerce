using Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(c => c.ProductBrand).WithMany().HasForeignKey(p => p.BrandId);
            builder.HasOne(c => c.ProductType).WithMany().HasForeignKey(p => p.TypeId);
            builder.Property(x => x.Price).HasColumnType("decimal(15,2)");




        }
    }
}
