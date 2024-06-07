﻿namespace PriseState.Core.Models;

public class AddOrganizationRequest
{
    /// <summary>
    ///     Имя организации
    /// </summary>
    public string Name { get; set; } = string.Empty;
    public int RegionId { get; set; }
}