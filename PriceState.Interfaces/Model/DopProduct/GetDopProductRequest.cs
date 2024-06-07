using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.DopProduct;

public class GetDopProductRequest : IPaginationRequest
{
    public long? DopProductId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}