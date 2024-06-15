using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Product;
using PriceState.Interfaces.Model.ProductGroup;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class ProductGroupService: IProductGroupService
{
	private readonly DataContext _db;

	public ProductGroupService(DataContext db)
	{
		_db = db;
	}

	public async Task<ProductGroup> CreateProductGroupAsync(long Id, long parentId, string name, long ProductTypeId)
	{
		var group = await _db.ProductGroups.FirstOrDefaultAsync(x => x.ParentId == parentId);
		var maxid  = _db.ProductGroups.Where(x => x.Id >= group.MinNomer && x.Id <= group.MaxNomer).Max(x => x.Id);
		if (await _db.ProductGroups.AllAsync(x => x.Id != parentId))
			throw new PriceStateException($"Unit {parentId} is not exists!", EnumErrorCode.EntityIsNotFound);

		if (maxid == 0)
			maxid = group.MinNomer;	
		var productGroup = new ProductGroup
		{
			Name = name,
			ParentId = parentId,
			Id = maxid+1
		};

		await _db.ProductGroups.AddAsync(productGroup);
		await _db.SaveChangesAsync();

		return productGroup;
	}



	public async Task<GetProductGroupsResponse> GetAllProductGroupAsync(GetProductGroupsRequest request)
	{
		var query = _db.ProductGroups.Where(x => x.ParentId == request.ParentId);
			//: _db.Products.AsQueryable();

		var result = await query.GetPageAsync<GetProductGroupsResponse, ProductGroup, ProductGroupModel>(request, x =>
			new ProductGroupModel
			{
				Id = x.Id,
				ParentId = x.ParentId,
				Name = x.Name
			});

		return result;
	}

	public async Task<GetProductGroupsResponse> GetProductGroupAsync(GetProductGroupRequest request)
	{
		var query = request.ProductGroupId.HasValue
			? _db.ProductGroups.Where(x => x.Id == request.ProductGroupId)
			: _db.ProductGroups.AsQueryable();

		var result = await query.GetPageAsync<GetProductGroupsResponse, ProductGroup, ProductGroupModel>(request, x =>
			new ProductGroupModel
			{
				Id = x.Id,
				ParentId = x.ParentId,
				Name = x.Name
			});

		return result;
	}

	public async Task RenameProductGroupAsync(long productId, string name)
	{
		var productGroup = await _db.ProductGroups.FirstOrDefaultAsync(x => x.Id == productId);
		if (productGroup is null)
			throw new PriceStateException($"ProductGroup{productId} is not exists!", EnumErrorCode.EntityIsNotFound);

		productGroup.Name = name;
		await _db.SaveChangesAsync();
	}
	

	public async Task DeleteProductGroupAsync(long productId)
	{
		_db.Products.Remove(new Product {Id = productId});
		await _db.SaveChangesAsync();
	}
	
}