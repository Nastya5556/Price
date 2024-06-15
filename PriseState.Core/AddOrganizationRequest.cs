namespace PriseState.Core;

public class AddOrganizationRequest
{
    /// <summary>
    ///     Название кафедры
    /// </summary>
    public int Id {get; set;}
    public string OrganizationName { get; set; } = string.Empty;

    /// <summary>
    ///     Идентификатор факультета
    /// </summary>
    public int RegionId { get; set; }
}