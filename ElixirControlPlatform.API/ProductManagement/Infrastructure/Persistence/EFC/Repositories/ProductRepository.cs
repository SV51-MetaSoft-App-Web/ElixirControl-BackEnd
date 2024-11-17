using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.ProductManagement.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.ProductManagement.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product> GetProductByProductName(GetProductByProductNameQuery query)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(product => product.ProductName == query.ProductName);
    }

    public async Task<IEnumerable<Product>> GetAllProductsByProfileId(GetAllProductsByProfileId query)
    {
        return await Context.Set<Product>().Where(product => product.ProfileId == query.ProfileId).ToListAsync();
    }
    
    public async Task<IEnumerable<Product?>> GetAllProductsByProfileIdAndProductName(GetAllProductsByProfileIdAndProductName query)
    {
        return await Context.Set<Product>().Where(product => product.ProfileId == query.ProfileId && product.ProductName == query.ProductName).ToListAsync();
    }
}