using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.FullProduct;

public class GetFullProductsResponse: IPaginationResponse<FullProductModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<FullProductModel> Items { get; set; }
}