using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.PriceOrganization;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;
[Route("PriceOrganization")]

public class PriceOrganizationController: ControllerBase
{
	private readonly IPriceOrganizationService _priceOrganization;

	public PriceOrganizationController(IPriceOrganizationService priceOrganization)
	{
		_priceOrganization = priceOrganization;
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
	public async Task<BaseResponse<long>> Add([FromBody] AddPriceOrganizationRequest model)
	{
		var result = await _priceOrganization.CreatePriceOrganizationAsync(model.OrganizationId,model.Price,model.Date,model.ProductId);
		return new BaseResponse<long>(result?.OrganizationId ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetPriceOrganizationsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetPriceOrganizationsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _priceOrganization.GetAllPriceOrganizationAsync(new GetPriceOrganizationsRequest {Page = request});
		return new BaseResponse<GetPriceOrganizationsResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetPriceOrganization)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<PriceOrganizationModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetPriceOrganizationsResponse>> GetPriceOrganization([FromQuery] GetPriceOrganizationRequest request)
	{
		var result = await _priceOrganization.GetPriceOrganizationAsync(request);
		
		return new BaseResponse<GetPriceOrganizationsResponse>(result);
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
	public async Task<BaseResponse> Rename([FromQuery] long organizationId, [FromQuery] decimal price,[FromQuery] DateTime date, [FromQuery] long productId)
	{
		await _priceOrganization.RenamePriceOrganizationAsync(organizationId,price,date,productId);
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
	public async Task<BaseResponse> Delete([FromQuery] long organizationId,[FromQuery] DateTime date, [FromQuery] long productId)
	{
		await _priceOrganization.DeletePriceOrganizationAsync(organizationId,date,productId);
		return new BaseResponse();
	}
}