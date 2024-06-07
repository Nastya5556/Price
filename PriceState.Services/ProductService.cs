using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Product;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class ProductService: IProductService
{
	private readonly DataContext _db;

	public ProductService(DataContext db)
	{
		_db = db;
	}

	public async Task<Product> AddProductAsync(long parentId, string name)
	{
		var group = await _db.ProductGroups.FirstOrDefaultAsync(x => x.ParentId == parentId);
		var maxid  = _db.Products.Where(x => x.Id >= group.MinNomer && x.Id <= group.MaxNomer).Max(x => x.Id);
		if (await _db.Products.AllAsync(x => x.Id != parentId))
			throw new PriceStateException($"Unit {parentId} is not exists!", EnumErrorCode.EntityIsNotFound);

		if (maxid == 0)
			maxid = group.MinNomer;	
		var product = new Product
		{
			Name = name,
			ParentId = parentId,
			Id = maxid+1
		};

		await _db.Products.AddAsync(product);
		await _db.SaveChangesAsync();

		return product;
	}


	public async Task<GetProductsResponse> GetAllProductAsync(GetProductsRequest request)
	{
		var query = _db.Products.Where(x => x.ParentId == request.ParentId);
			//: _db.Products.AsQueryable();

		var result = await query.GetPageAsync<GetProductsResponse, Product, ProductModel>(request, x =>
			new ProductModel
			{
				Id = x.Id,
				ParentId = x.ParentId,
				Name = x.Name
			});

		return result;
	}

	public async Task<GetProductsResponse> GetProductAsync(GetProductRequest request)
	{
		var query = request.ProductId.HasValue
			? _db.Products.Where(x => x.Id == request.ProductId)
			: _db.Products.AsQueryable();

		var result = await query.GetPageAsync<GetProductsResponse, Product, ProductModel>(request, x =>
			new ProductModel
			{
				Id = x.Id,
				ParentId = x.ParentId,
				Name = x.Name
			});

		return result;
	}

	public async Task RenameProductAsync(long productId, string name)
	{
		var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == productId);
		if (product is null)
			throw new PriceStateException($"Product{productId} is not exists!", EnumErrorCode.EntityIsNotFound);

		product.Name = name;
		await _db.SaveChangesAsync();
	}
	

	public async Task DeleteProductAsync(long productId)
	{
		_db.Products.Remove(new Product {Id = productId});
		await _db.SaveChangesAsync();
	}
	
}