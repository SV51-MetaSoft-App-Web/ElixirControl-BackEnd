using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.ProductManagement.Domain.Repositories;
using ElixirControlPlatform.API.ProductManagement.Domain.Services;

namespace ElixirControlPlatform.API.ProductManagement.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository ) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsByProfileId query)
    {
        return await productRepository.GetAllProductsByProfileId(query);
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsByProfileIdAndProductName query)
    {
        return await productRepository.GetAllProductsByProfileIdAndProductName(query);
    }

    public async Task<Product?> Handle(GetProductByProductNameQuery query)
    {
        return await productRepository.GetProductByProductName(query);
    }
}