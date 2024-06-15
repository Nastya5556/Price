using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Data.Reports;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.PriceOrganization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class PriceOrganizationService : IPriceOrganizationService
{
    private readonly DataContext _db;

    public PriceOrganizationService(DataContext db)
    {
        _db = db;
    }

    public async Task<PriceOrganization> CreatePriceOrganizationAsync(long organizationId, decimal price, DateTime date,
        long productId)
    {
        if (await _db.Organizations.AllAsync(x => x.Id != organizationId))
            throw new PriceStateException($"Organization {organizationId} is not exists!",
                EnumErrorCode.EntityIsNotFound);

        if (await _db.Products.AllAsync(x => x.Id != productId))
            throw new PriceStateException($"Product {productId} is not exists!", EnumErrorCode.EntityIsNotFound);

        if (await _db.PriceOrganizations.AnyAsync(x =>
                x.FullProductId == productId && x.OrganizationId == organizationId && x.Date == date))
            throw new PriceStateException($"There is such a price", EnumErrorCode.EntityIsAlreadyExists);
        var priceOrganization = new PriceOrganization
        {
            Date = date,
            OrganizationId = organizationId,
            Price = price,
            FullProductId = productId
        };

        await _db.PriceOrganizations.AddAsync(priceOrganization);
        await _db.SaveChangesAsync();

        return priceOrganization;
    }
    

    public Task<GetPriceOrganizationsResponse> GetAllPriceOrganizationAsync(GetPriceOrganizationsRequest request)
    {
        throw new NotImplementedException();
    }


    /* public async Task<GetPriceOrganizationsResponse> GetAllPriceOrganizationAsync(GetPriceOrganizationsRequest request)
    {
        var products = _db.Products.Where(p => EF.Functions.Like(p.Name, request.Name + "%"));
        var query = _db.PriceOrganizations.Where(pr => products.Equals(pr.Product)).ToList();
        

        var result = await query.GetPageAsync<GetPriceOrganizationsResponse, PriceOrganization, PriceOrganizationModel>(request, x =>
            new OrganizationModel
            {
                Id = x.Id,
                RegionId = x.RegionId,
                Name = x.Name
            });

        return result;
    }*/

   /* public async Task<List<AvgPrice>> GetProductsByCtegoryAsync()
    {
        DateTime date1 = new DateTime(2024, 6, 1);
        DateTime date2 = new DateTime(2024, 6, 30);
        string sqlQuery = $"SELECT * FROM avg_price ({date1},{date2})";
        return await _db.AvgPrices.FromSqlRaw(sqlQuery).ToListAsync();

    }*/
    public async Task<GetPriceOrganizationsResponse> GetPriceOrganizationAsync(GetPriceOrganizationRequest request)
    {
        var query = request.OrganizationId.HasValue
            ? _db.PriceOrganizations.Where(x => x.OrganizationId == request.OrganizationId)
            : _db.PriceOrganizations.AsQueryable();

        var result = await query.GetPageAsync<GetPriceOrganizationsResponse, PriceOrganization, PriceOrganizationModel>(request, x =>
            new PriceOrganizationModel
            {
                FullProductId = x.FullProductId,
                OrganizationId  = x.OrganizationId,
                Price = x.Price
            });

        return result;
    }

    public async Task RenamePriceOrganizationAsync(long organizationId, decimal price, DateTime date, long productId)
    {
        var priceOrganization = await _db.PriceOrganizations.FirstOrDefaultAsync(x =>
            x.FullProductId == productId && x.OrganizationId == organizationId && x.Date == date);
        if (priceOrganization is null)
            throw new PriceStateException($"PriceOrganization is not exists!", EnumErrorCode.EntityIsNotFound);

        priceOrganization.Price = price;
        await _db.SaveChangesAsync();
    }


    public async Task DeletePriceOrganizationAsync(long organizationId, DateTime date, long productId)
    {
        var priceOrganization = await _db.PriceOrganizations.FirstOrDefaultAsync(x =>
            x.FullProductId == productId && x.OrganizationId == organizationId && x.Date == date);
        _db.PriceOrganizations.Remove(priceOrganization);
        await _db.SaveChangesAsync();
    }
}