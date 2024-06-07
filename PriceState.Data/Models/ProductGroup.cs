namespace PriceState.Data.Models;

public class ProductGroup
{
    public long Id { get; set; }
    
    public long ParentId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public long ProductTypeId { get; set; }
    
    public long MaxNomer { get; set; }
    
    public long MinNomer { get; set; }
    public ProductType ProductType { get; set; }
    
    public ProductGroup Parent { get; set; }
    
    public List<ProductGroup> ProductGroups { get; set; } = null!;
    
    public List<Product> Products { get; set; } = null!;
}