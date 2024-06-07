using PriceState.Data.Models;
using PriceState.Interfaces.Model.DopProduct;


namespace PriceState.Interfaces;

public interface IDopProductService
{
    Task<DopProduct?> CreateDopProductAsync(string name);

    Task<GetDopProductsResponse> GetAllDopProductAsync(GetDopProductsRequest request);

    Task<DopProduct> GetDopProductAsync(long DopProductId);

    Task RenameDopProductAsync(long DopProductId, string name);

    Task DeleteDopProductAsync(long DopProductId);
}