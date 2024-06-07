using PriceState.Data.Models;
using PriceState.Interfaces.Model.ProductGroup;

namespace PriceState.Interfaces;

public interface IProductGroupService
{
    Task<ProductGroup?> CreateProductGroupAsync(long Id, long ParentId, string Name, long ProductTypeId);

    Task<GetProductGroupsResponse> GetAllProductGroupAsync(GetProductGroupsRequest request);

    Task<GetProductGroupsResponse?> GetProductGroupAsync(GetProductGroupRequest request);

    Task RenameProductGroupAsync(long Id,string Name);

    Task DeleteProductGroupAsync(long Id);
}