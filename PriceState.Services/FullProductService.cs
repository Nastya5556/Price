using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.FullProduct;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class FullProductService: IFullProductService
{
	private readonly DataContext _db;

	public FullProductService(DataContext db)
	{
		_db = db;
	}
	

	public async Task<FullProduct?> CreateFullProductAsync( int unitId, long productId, long dopProductId)
	{
		if (await _db.Units.AllAsync(x => x.Id != unitId))
			throw new PriceStateException($"Unit {unitId} is not exists!", EnumErrorCode.EntityIsNotFound);
		if (await _db.Products.AllAsync(x => x.Id != productId))
			throw new PriceStateException($"Product {productId} is not exists!", EnumErrorCode.EntityIsNotFound);
		if (await _db.DopProducts.AllAsync(x => x.Id != dopProductId))
			throw new PriceStateException($"DopProduct {dopProductId} is not exists!", EnumErrorCode.EntityIsNotFound);
		var fullProduct = new FullProduct
		{
			UnitId = unitId,
			DopProductId = dopProductId,
			ProductId = productId
		};

		await _db.FullProducts.AddAsync(fullProduct);
		await _db.SaveChangesAsync();

		return fullProduct;
		
	}

	public async Task<GetFullProductsResponse> GetAllFullProductAsync(GetFullProductsRequest request)
	{
		var query = _db.FullProducts.Where(x => x.ProductId == request.ProductId);
			//: _db.Products.AsQueryable();

		var result = await query.GetPageAsync<GetFullProductsResponse, FullProduct, FullProductModel>(request, x =>
			new FullProductModel
			{
				ProductId  = x.ProductId,
				DopProductId = x.DopProductId,
				UnitId = x.UnitId
			});

		return result;
	}

	public Task<GetFullProductsResponse> Search(GetFullProductsRequest request)
	{
		var products = _db.Products.Where(x => x.Name.Contains(request.Search)).Select(x=>x.Id);
		var query = _db.FullProducts.Where(x => products.Contains(x.ProductId));
		
		
		
		var result = query.GetPageAsync<GetFullProductsResponse, FullProduct, FullProductModel>(request, x =>
			new FullProductModel
			{
				ProductId  = x.ProductId,
				DopProductId = x.DopProductId,
				UnitId = x.UnitId
			});

		return result;
	}

	public async Task<GetFullProductsResponse> GetFullProductAsync(GetFullProductRequest request)
	{
		var query = request.FullProductId.HasValue
			? _db.FullProducts.Where(x => x.Id == request.FullProductId)
			: _db.FullProducts.AsQueryable();

		var result = await query.GetPageAsync<GetFullProductsResponse, FullProduct, FullProductModel>(request, x =>
			new FullProductModel
			{
				ProductId  = x.ProductId,
				DopProductId = x.DopProductId,
				UnitId = x.UnitId
			});

		return result;
	}

	public async Task RenameFullProductAsync(long fullProductId, string name)
	{
		var fullProduct = await _db.FullProducts.FirstOrDefaultAsync(x => x.Id == fullProductId);
		if (fullProduct is null)
			throw new PriceStateException($"FullProduct{fullProductId} is not exists!", EnumErrorCode.EntityIsNotFound);
		
		await _db.SaveChangesAsync();
	}
	

	public async Task DeleteFullProductAsync(long fullProductId)
	{
		_db.FullProducts.Remove(new FullProduct {Id = fullProductId});
		await _db.SaveChangesAsync();
	}
	
}