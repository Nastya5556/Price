using PriceState.Data.Models;

namespace PriceState.Data.Reports;

public class LastPrice
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    
    public long FullProductId { get; set; }
    
    public long ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public long OrganizationId { get; set; }
    
    public  string OrganizationName { get; set; }
    
    public decimal Price { get; set; }
    
    public Organization Organization { get; set; }
    public FullProduct FullProduct { get; set; }
    public Product Product { get; set; }
}