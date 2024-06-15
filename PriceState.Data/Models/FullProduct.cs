namespace PriceState.Data.Models;

public class FullProduct
{
    public long Id { get; set; }
    public int UnitId { get; set; }
    
    public long ProductId { get; set; }
    
    public string Name { get; set; }

    public Unit Unit { get; set; }
    
    public Product Product { get; set; }

    public List<PriceOrganization> PriceOrganizations { get; set; } = null!;
    
}