namespace PriseState.Core.Models;

public class AddProductRequest
{
    /// <summary>
    ///     Имя организации
    /// </summary>
    public string Name { get; set; } = string.Empty;
    public long ParentId { get; set; }
}