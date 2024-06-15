using PriceState.Data.Models;

namespace PriceState.Data.Reports;

public class AvgPrice
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    
    public string ProductName { get; set; } = String.Empty;
    
    public string RegionName { get; set; } = String.Empty;

    public long ProductId { get; set; } 
    
    public Region Region { get; set; }
    public Product Product { get; set; }
    
}