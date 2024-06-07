using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductType;

public class GetProductTypesRequest: IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}