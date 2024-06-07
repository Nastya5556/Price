using PriceState.Interfaces.Model.Product;
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.PriceOrganization;

public class GetPriceOrganizationRequest: IPaginationRequest
{

    public DateTime Date { get; set; }
    
    public ProductModel ProductModel { get; set; }

    public long ProductId { get; set; }
    
    public string Name { get; set; }
    public long? OrganizationId { get; set; }
    public Page Page { get; set; } = new Page();
}