//using PriceState.Data.Models;

namespace PriceState.Interfaces.Model.PriceOrganization;

public class PriceOrganizationModel
{
    public decimal Price { get; set; }
    
    public DateTime Date { get; set; }

    public long FullProductId { get; set; }

    public long OrganizationId { get; set; }
    
}