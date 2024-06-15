using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductGroup;

public class ProductGroupModel
{
    public long Id { get; set; }
    
    public long? ParentId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public long ProductTypeId { get; set; }
    
    public long MaxNomer { get; set; }
    
    public long MinNomer { get; set; }
}