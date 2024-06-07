using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class ProductTypeConfigurations
{
    public ProductTypeConfigurations(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(x => x.Id);

    }
}