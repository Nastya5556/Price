using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.ProductType;

public class GetProductTypesResponse: IPaginationResponse<ProductTypeModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ProductTypeModel> Items { get; set; }
}