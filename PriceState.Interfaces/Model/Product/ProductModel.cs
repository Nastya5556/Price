namespace PriceState.Interfaces.Model.Product;

public class ProductModel
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public long ParentId { get; set; }

}