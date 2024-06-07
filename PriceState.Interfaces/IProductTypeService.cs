using PriceState.Data.Models;
using PriceState.Interfaces.Model.ProductType;

namespace PriceState.Interfaces;

public interface IProductTypeService
{
    Task<ProductType?> CreateProductTypeAsync(string name);

    Task<GetProductTypesResponse> GetAllProductTypeAsync(GetProductTypesRequest request);

    Task<ProductType> GetProductTypeAsync(long ProductTypeId);

    Task RenameProductTypeAsync(long ProductTypeId, string name);

    Task DeleteProductTypeAsync(long ProductTypeId);
}