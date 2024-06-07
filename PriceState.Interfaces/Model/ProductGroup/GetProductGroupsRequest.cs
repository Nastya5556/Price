using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductGroup;

public class GetProductGroupsRequest: IPaginationRequest
{
    public long? ParentId { get; set; } 
    
    public long ProductTypeId { get; set; }

    public Page Page { get; set; } = new Page();
}