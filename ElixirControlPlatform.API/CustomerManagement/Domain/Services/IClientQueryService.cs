using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Queries;
using Mysqlx.Crud;

namespace ElixirControlPlatform.API.CustomerManagement.Domain.Services;

/// <summary>
/// Client query service interface
/// </summary>
public interface IClientQueryService
{
    /// <summary>
    /// Handle get client by id query
    /// </summary>
    /// <param name="query">GetClientsByIdQuery query</param>
    /// <returns>
    /// The client if successful otherwise null
    /// </returns>
    /// <see cref="GetClientByIdQuery"/>
    Task<Client?> Handle(GetClientByIdQuery query);
    
    /// <summary>
    /// Handle get all clients by dni query
    /// </summary>
    /// <param name="query">GetAllClientsByDniQuery query  </param>
    /// <returns>
    /// The list of clients if successful otherwise null
    /// </returns>
    /// see <see cref="GetAllClientsByDniQuery"/>
    Task<Client?> Handle(GetAllClientsByDniQuery query);
    
    
    Task<IEnumerable<Client>> Handle(GetAllClientsQuery query);
    Task<IEnumerable<Client>> Handle(GetAllClientsByProfileId query);
}