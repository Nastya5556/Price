using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PriceState.Data.Models;

public class Product
{

    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public long ParentId { get; set; }
   

   // public int UnitId { get; set; }
   // public Unit Unit { get; set; }
    public List<PriceOrganization> PriceOrganizations { get; set; } = null!;
    
    public List<FullProduct> FullProducts { get; set; } = null!;
    public ProductGroup  ProductGroup { get; set; } = null!;
}