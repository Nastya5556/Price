namespace PriseState.Core.Models;

public class AddProductGroupRequest
{
    public string Name { get; set; } = string.Empty;
    
    public long Id { get; set; }
    public long ParentId { get; set; }
    public long ProductTypeId { get; set; }
}