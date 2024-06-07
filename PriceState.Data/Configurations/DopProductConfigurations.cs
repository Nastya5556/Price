using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceState.Data.Models;

namespace PriceState.Data.Configurations;

public class DopProductConfigurations
{
    public DopProductConfigurations(EntityTypeBuilder<DopProduct> builder)
    {
        builder.HasKey(x => x.Id);

    }
}