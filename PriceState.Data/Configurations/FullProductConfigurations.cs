using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class FullProductConfigurations
{
    public FullProductConfigurations(EntityTypeBuilder<FullProduct> builder)
    {
        builder.HasKey(x => new { x.Id });

        builder.HasOne(x => x.Unit)
            .WithMany(x => x.FullProducts)
            .HasForeignKey(x => x.UnitId);
    
        builder.HasOne(x => x.Product)
            .WithMany(x => x.FullProducts)
            .HasForeignKey(x => x.ProductId);
        
        builder.HasOne(x => x.DopProduct)
            .WithMany(x => x.FullProducts)
            .HasForeignKey(x => x.DopProductId);
    }
}