using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Product;

public class GetProductsRequest: IPaginationRequest
{
    
    public long ProductId { get; set; }
    
    public long ParentId { get; set; }

    public Page Page { get; set; } = new Page();
}