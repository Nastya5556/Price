using PriceState.Data.Models;

namespace PriceState.Data.Reports;

public class Otchet5
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    
    public decimal AvgPrice { get; set; }
    
    public decimal IndexLastMonth { get; set; }
    
    public decimal IndexLastYear { get;set;}
    
    public PriceOrganization PriceOrganization { get; set; }
    public FullProduct FullProduct { get; set; }
    public Product Product { get; set; }
    public ProductGroup ProductGroup { get; set; }
}