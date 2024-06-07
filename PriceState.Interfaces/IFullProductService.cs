using PriceState.Data.Models;
using PriceState.Interfaces.Model.FullProduct;

namespace PriceState.Interfaces;

public interface IFullProductService
{
    Task<FullProduct?> CreateFullProductAsync( int UnitId, long ProductId, long DopProductId);

    Task<GetFullProductsResponse> GetAllFullProductAsync(GetFullProductsRequest request);
    
    Task<GetFullProductsResponse> Search (GetFullProductsRequest request);

    Task<GetFullProductsResponse?> GetFullProductAsync(GetFullProductRequest request);

    Task RenameFullProductAsync(long Id,string Name);

    Task DeleteFullProductAsync(long Id);
}