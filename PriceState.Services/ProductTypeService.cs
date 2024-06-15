using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.ProductType;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class ProductTypeService: IProductTypeService
{
    private readonly DataContext _db;

    public ProductTypeService(DataContext db)
    {
        _db = db;
    }

    public async Task<ProductType> CreateProductTypeAsync( string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new PriceStateException("Incorrect ProductType name!", EnumErrorCode.ArgumentIsIncorrect);


        var productType = new ProductType
        {
            Name = name,

        };

        await _db.ProductTypes.AddAsync(productType);
        await _db.SaveChangesAsync();

        return productType;
    }
	


    public async Task<GetProductTypesResponse> GetAllProductTypeAsync(GetProductTypesRequest request)
    {
        return await _db.ProductTypes.GetPageAsync<GetProductTypesResponse, ProductType, ProductTypeModel>(request, productType =>
            new ProductTypeModel
            {
                Id = productType.Id,
                Name = productType.Name
            });
    }



    public async Task<ProductType> GetProductTypeAsync(long productTypeId)
    {
        return await _db.ProductTypes.FirstOrDefaultAsync(x => x.Id == productTypeId) 
               ?? throw new PriceStateException($"ProductType {productTypeId} is not found!", EnumErrorCode.EntityIsNotFound);
    }



    public async Task RenameProductTypeAsync(long productTypeId, string name)
    {
        var productType = await _db.ProductTypes.FirstOrDefaultAsync(x => x.Id == productTypeId);
        if (productType is null)
            throw new PriceStateException($"ProductType {productTypeId} is not exists!", EnumErrorCode.EntityIsNotFound);

        productType.Name = name;
        await _db.SaveChangesAsync();
    }
	
	
    public async Task DeleteProductTypeAsync(long productTypeId)
    {
        _db.ProductTypes.Remove(new ProductType {Id = productTypeId});
        await _db.SaveChangesAsync();
    }
	
}