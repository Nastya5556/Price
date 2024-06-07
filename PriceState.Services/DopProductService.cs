using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.DopProduct;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class DopProductService: IDopProductService
{
    private readonly DataContext _db;

    public DopProductService(DataContext db)
    {
        _db = db;
    }

    public async Task<DopProduct> CreateDopProductAsync( string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new PriceStateException("Incorrect DopProduct name!", EnumErrorCode.ArgumentIsIncorrect);

        if (await _db.DopProducts.AnyAsync(x => x.Name == name))
            throw new PriceStateException($"DopProduct with name {name} is already exists!", EnumErrorCode.EntityIsAlreadyExists);


        var dopProduct = new DopProduct
        {
            Name = name,

        };

        await _db.DopProducts.AddAsync(dopProduct);
        await _db.SaveChangesAsync();

        return dopProduct;
    }
	


    public async Task<GetDopProductsResponse> GetAllDopProductAsync(GetDopProductsRequest request)
    {
        return await _db.DopProducts.GetPageAsync<GetDopProductsResponse, DopProduct, DopProductModel>(request, dopProduct =>
            new DopProductModel
            {
                Id = dopProduct.Id,
                Name = dopProduct.Name
            });
    }



    public async Task<DopProduct> GetDopProductAsync(long dopProductId)
    {
        return await _db.DopProducts.FirstOrDefaultAsync(x => x.Id == dopProductId) 
               ?? throw new PriceStateException($"DopProduct {dopProductId} is not found!", EnumErrorCode.EntityIsNotFound);
    }



    public async Task RenameDopProductAsync(long dopProductId, string name)
    {
        var dopProduct = await _db.DopProducts.FirstOrDefaultAsync(x => x.Id == dopProductId);
        if (dopProduct is null)
            throw new PriceStateException($"DopProduct {dopProductId} is not exists!", EnumErrorCode.EntityIsNotFound);

        dopProduct.Name = name;
        await _db.SaveChangesAsync();
    }
	
	
    public async Task DeleteDopProductAsync(long dopProductId)
    {
        _db.DopProducts.Remove(new DopProduct {Id = dopProductId});
        await _db.SaveChangesAsync();
    }
	
}