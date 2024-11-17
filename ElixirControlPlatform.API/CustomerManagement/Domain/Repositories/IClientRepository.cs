﻿using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
 
    /// <summary>
    /// Find all <see cref="Client"/> by <paramref name="dni"/>.
    /// </summary>
    /// <param name="dni">The Clients API Key generated by Clients provides</param>
    /// <returns>
    /// A collection of <see cref="Client"/> that matches the <paramref name="dni"/>
    /// </returns>
    Task<Client?> FindByDniAsync(int dni);
    
    
    
}