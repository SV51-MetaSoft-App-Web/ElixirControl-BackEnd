using System.Security.Cryptography;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;

namespace ElixirControlPlatform.API.ProductManagement.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
    
    Task<IEnumerable<Product>> Handle(GetAllProductsByProfileId query);
    
    Task<IEnumerable<Product>> Handle(GetAllProductsByProfileIdAndProductName query);
    
    Task<Product?> Handle(GetProductByProductNameQuery query);
    
}