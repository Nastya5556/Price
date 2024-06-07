namespace PriceState.Data.Models;

public class DopProduct
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public List<FullProduct> FullProducts { get; set; } = null!;
}