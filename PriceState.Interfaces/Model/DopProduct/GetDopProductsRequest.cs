using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.DopProduct;

public class GetDopProductsRequest: IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}