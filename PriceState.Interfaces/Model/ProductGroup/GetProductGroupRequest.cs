using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductGroup;

public class GetProductGroupRequest: IPaginationRequest
{

    public long? ProductGroupId { get; set; }
    
    public Page Page { get; set; } = new Page();
}