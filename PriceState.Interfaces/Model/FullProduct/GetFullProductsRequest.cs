using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.FullProduct;

public class GetFullProductsRequest: IPaginationRequest
{
    public long FullProductsId { get; set; }
    
    public int UnitId { get; set; }
    
    public long ProductId { get; set; }
    
    public string Search { get; set; } = string.Empty;

    public Page Page { get; set; } = new Page();
}