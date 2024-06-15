namespace PriseState.Core.Models;

public class AddPriceOrganizationRequest
{
    public decimal Price { get; set; } 
    
    public DateTime Date { get; set; }
    
    public long OrganizationId { get; set; }
    public long ProductId { get; set; }
}