using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductType;

public class GetProductTypeRequest : IPaginationRequest
{
    public long? ProductTypeId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}