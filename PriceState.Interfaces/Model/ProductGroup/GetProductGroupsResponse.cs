
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductGroup;

public class GetProductGroupsResponse: IPaginationResponse<ProductGroupModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ProductGroupModel> Items { get; set; }
}