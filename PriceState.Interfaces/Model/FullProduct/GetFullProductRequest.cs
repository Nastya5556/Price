using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.FullProduct;

public class GetFullProductRequest: IPaginationRequest
{
    public long? FullProductId { get; set; }
    
    
    public Page Page { get; set; } = new Page();
}