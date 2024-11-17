using ElixirControlPlatform.API.OrderManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
﻿using System.Security.Cryptography;
namespace ElixirControlPlatform.API.OrderManagement.Domain.Services;

/// <summary>
/// Order query service interface
/// </summary>
public interface IOrderQueryService
{
    /// <summary>
    /// Handle get order by id query
    /// </summary>
    /// <param name="query"></param>
    /// <returns>
    /// The order if successful otherwise null
    /// </returns>
    Task<Order?> Handle(GetOrderByIdQuery query);
    Task<IEnumerable<Order>> Handle(GetAllOrdersByProfileId query); 
}