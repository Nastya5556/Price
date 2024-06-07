namespace PriceState.Data.Models;

public class ProductType
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public List<ProductGroup> ProductGroups { get; set; } = null!;
}