using PriceState.Data.Models;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.PriceOrganization;

namespace PriceState.Interfaces;

public interface IPriceOrganizationService
{
    Task<PriceOrganization?> CreatePriceOrganizationAsync(long organizationId, decimal Price, DateTime Date, long productId);

    Task<GetPriceOrganizationsResponse> GetAllPriceOrganizationAsync(GetPriceOrganizationsRequest request);

    Task<GetPriceOrganizationsResponse?> GetPriceOrganizationAsync(GetPriceOrganizationRequest request);

    Task RenamePriceOrganizationAsync(long organizationId, decimal price, DateTime date, long productId);

    Task DeletePriceOrganizationAsync(long organizationId, DateTime date, long productId);
}