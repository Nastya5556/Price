using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class ProductGroupConfigurations
{
    public ProductGroupConfigurations(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.HasKey(x => new { x.Id });

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.ProductGroups)
            .HasForeignKey(x => x.ParentId);
        
        builder.HasOne(x => x.ProductType)
            .WithMany(x => x.ProductGroups)
            .HasForeignKey(x => x.ProductTypeId);
        
    }
}