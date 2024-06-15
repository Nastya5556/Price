namespace PriseState.Core.Models;

public class AddRegionRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int RegionId { get; set; }
}