using PriceState.Interfaces.Model.Region;
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.DopProduct;

public class GetDopProductsResponse: IPaginationResponse<DopProductModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<DopProductModel> Items { get; set; }
}