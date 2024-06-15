namespace PriceState.Data.Models;

public class PriceOrganization
{

    
    public decimal Price { get; set; }
    
    public DateTime Date { get; set; }
    
    public FullProduct FullProduct { get; set; }
    
    public long FullProductId { get; set; }
    
    
    public Organization Organization { get; set; }

    public long OrganizationId { get; set; }
    
    
}