using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.DopProduct;
using PriceState.Interfaces.Model.ProductType;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;

public class DopProductController: Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IDopProductService _dopProduct;

	public DopProductController(IDopProductService dopProduct)
	{
		_dopProduct = dopProduct;
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
	public async Task<BaseResponse<long>> Add([FromBody] AddDopProductRequest model)
	{
		var result = await _dopProduct.CreateDopProductAsync(model.Name);
		return new BaseResponse<long>(result?.Id ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetDopProductsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetDopProductsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _dopProduct.GetAllDopProductAsync(new GetDopProductsRequest {Page = request});
		return new BaseResponse<GetDopProductsResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(Get)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<(long Id, string Name)>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<(long Id, string Name)>> Get([FromQuery] [Required] long id)
	{
		var result = await _dopProduct.GetDopProductAsync(id);
		return new BaseResponse<(long Id, string Name)>((result.Id, result.Name));
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
		await _dopProduct.RenameDopProductAsync(id,name);
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
		await _dopProduct.DeleteDopProductAsync(id);
		return new BaseResponse();
	}
}