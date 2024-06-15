using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.FullProduct;
using PriceState.Interfaces.Model.PriceOrganization;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;
[Route("FullProduct")]
public class FullProductController: ControllerBase
{
	private readonly IFullProductService _fullProduct;

	public FullProductController(IFullProductService fullProduct)
	{
		_fullProduct = fullProduct;
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
	public async Task<BaseResponse<long>> Add([FromBody] AddFullProductRequest model)
	{
		var result = await _fullProduct.CreateFullProductAsync(model.UnitId,model.ProductId);
		return new BaseResponse<long>(result?.ProductId ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetFullProductsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetFullProductsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _fullProduct.GetAllFullProductAsync(new GetFullProductsRequest {Page = request});
		return new BaseResponse<GetFullProductsResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetFullProduct)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<FullProductModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetFullProductsResponse>> GetFullProduct([FromQuery] GetFullProductRequest request)
	{
		var result = await _fullProduct.GetFullProductAsync(request);
		return new BaseResponse<GetFullProductsResponse>(result);
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
		await _fullProduct.RenameFullProductAsync(id,name);
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
		await _fullProduct.DeleteFullProductAsync(id);
		return new BaseResponse();
	}
}