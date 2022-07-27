using StockApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockApi.Data.Config
{
    // Model oluşturmak için kullanılan kural kümesi
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");
            //entity.Property(x => x.ProductId).IsRequired();
            entity.Property(x => x.ProductName).IsRequired().HasColumnType("nvarchar(500)");
            entity.Property(x => x.ProductPrice).IsRequired().HasColumnType("nvarchar(500)");
            entity.Property(x => x.ProductCount).IsRequired().HasColumnType("nvarchar(500)");
        }
    }
}
