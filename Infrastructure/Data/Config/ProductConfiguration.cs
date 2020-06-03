using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // This is saying make the Id property required
            builder.Property(p => p.Id).IsRequired();

            // This is saying make the Id property required i.e. it can not be NULL, and can not be greater than 100 characters long
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);

            // This has to be a decimal with 2 decimal places
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.Property(p => p.PictureUrl).IsRequired();

            // Table relationship section
            // Each product has a single 'brand' that it is related to. Each brand can be related to many products
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);

            // Each product is related to a single 'type'. A product type can be related to many products
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
            
        }
    }
}