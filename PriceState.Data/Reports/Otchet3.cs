using PriceState.Data.Models;

namespace PriceState.Data.Reports;

public class Otchet3
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    
    public string FullProductName { get; set; }
    
    public DateTime Date { get; set; }

    public decimal Price { get; set; }
    
    public decimal Avg { get; set; }
    
    public decimal AvgTotal { get; set; }
    
    public PriceOrganization PriceOrganization { get; set; }
    public FullProduct FullProduct { get; set; }
    public Product Product { get; set; }
}