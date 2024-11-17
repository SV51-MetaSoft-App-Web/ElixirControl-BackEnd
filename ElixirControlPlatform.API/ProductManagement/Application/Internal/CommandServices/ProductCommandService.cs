using ElixirControlPlatform.API.ProductManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.ProductManagement.Domain.Repositories;
using ElixirControlPlatform.API.ProductManagement.Domain.Services;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;

namespace ElixirControlPlatform.API.ProductManagement.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IProfileRepository profileRepository, IUnitOfWOrk unitOfWork) : IProductCommandService
{
    
    
    public async Task<Product> Handle(CreateProductCommand command, Guid profileId)
    {
        var profile =  await profileRepository.GetProfileByIdAsync(profileId);

        if (profile is null) throw new Exception("Profile not found");
        
        var product = new Product(command, profileId);
        
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        
        return product;
    }

    public async Task<Product?> Handle(UpdateProductCommand command, int ProductId)
    {
        var product = await productRepository.FindByIdAsync(ProductId);
        
        if (product is null) throw new Exception("Product not found");
        
        product.Update(command);

        productRepository.Update(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<bool> Handle(DeleteProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.Id);
        
        if (product is null) return false;
        
        productRepository.Remove(product);
        await unitOfWork.CompleteAsync();
        
        return true;
    }
}