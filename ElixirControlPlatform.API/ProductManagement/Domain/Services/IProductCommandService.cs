using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;

namespace ElixirControlPlatform.API.ProductManagement.Domain.Services;

public interface IProductCommandService
{
    public Task<Product?> Handle(CreateProductCommand command, Guid profileId);
    
    public Task<Product?> Handle(UpdateProductCommand command, int ProductId);
    
    public Task<bool> Handle(DeleteProductCommand command);
}