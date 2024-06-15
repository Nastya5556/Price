using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.ProductGroup;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;


namespace PriseState.Core.Controller;
[Route("ProductGroup")]
public class ProductGroupController: ControllerBase
{
	private readonly IProductGroupService _productGroupService;

	public ProductGroupController(IProductGroupService productGroup)
	{
		_productGroupService = productGroup;
	}

	/// <summary>
	///     Добавить регион
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	[Route($"{nameof(Add)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse<long>> Add([FromBody] AddProductGroupRequest model)
	{
		var result = await _productGroupService.CreateProductGroupAsync(model.Id, model.ParentId, model.Name, model.ProductTypeId);
		return new BaseResponse<long>(result?.Id ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetProductGroupsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetProductGroupsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _productGroupService.GetAllProductGroupAsync(new GetProductGroupsRequest {Page = request});
		return new BaseResponse<GetProductGroupsResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetProductGroup)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<ProductGroupModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetProductGroupsResponse>> GetProductGroup([FromQuery] GetProductGroupRequest request)
	{
		var result = await _productGroupService.GetProductGroupAsync(request);
		return new BaseResponse<GetProductGroupsResponse>(result);
	}

	/// <summary>
	///     Переименовать факультет
	/// </summary>
	/// <returns></returns>
	[HttpPatch]
	[Route($"{nameof(Rename)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Rename([FromQuery] long id,[FromQuery] string name)
	{
		await _productGroupService.RenameProductGroupAsync(id,name);
		return new BaseResponse();
	}

	/// <summary>
	///     Удалить факультет
	/// </summary>
	/// <returns></returns>
	[HttpDelete]
	[Route($"{nameof(Delete)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Delete([FromQuery] long id)
	{
		await _productGroupService.DeleteProductGroupAsync(id);
		return new BaseResponse();
	}
}