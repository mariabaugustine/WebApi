using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApi.Models;

namespace ProductApi.DBContext.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired().
                            HasMaxLength(25);
            builder.Property(x=>x.ProductDescription).IsRequired().
                            HasMaxLength(25);
        }
    }
}
