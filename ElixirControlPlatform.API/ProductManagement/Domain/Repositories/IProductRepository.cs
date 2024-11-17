using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.ProductManagement.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    
    Task<Product> GetProductByProductName(GetProductByProductNameQuery query);
    Task<IEnumerable<Product>> GetAllProductsByProfileId(GetAllProductsByProfileId query);
    Task<IEnumerable<Product?>> GetAllProductsByProfileIdAndProductName(GetAllProductsByProfileIdAndProductName query);
}