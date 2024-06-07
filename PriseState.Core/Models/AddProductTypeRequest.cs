namespace PriseState.Core.Models;

public class AddProductTypeRequest
{
    public string Name { get; set; } = string.Empty;
    
    public int ProductTypeId { get; set; }
}