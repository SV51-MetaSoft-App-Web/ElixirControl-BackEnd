using System.Net.Mime;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.ProductManagement.Domain.Model.Queries;
using ElixirControlPlatform.API.ProductManagement.Domain.Services;
using ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Resources;
using ElixirControlPlatform.API.ProductManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ElixirControlPlatform.API.ProductManagement.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Profile Endpoints.")]
public class ProductController(IProductCommandService productCommandService, IProductQueryService productQueryService) : ControllerBase
{
    
    // GET -----------------------------------------------------------------------------------------------------------
    [HttpGet("{productId}")]
    [SwaggerOperation("Get Product by ProductId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Product found", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found")]
    public async Task<IActionResult> GetProductByProductId(int productId)
    {
       var getProductByIdQuery = new GetProductByIdQuery(productId); 
       
       var product = await productQueryService.Handle(getProductByIdQuery);
       
       if (product is null) return BadRequest();
       var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
       
       return Ok(productResource);
    }
    
    // GET ALL PRODUCTS BY PROFILE ID --------------------------------------------------------------------------------
    [HttpGet("profile/{profileId}")]
    [SwaggerOperation("Get All Products by ProfileId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Products found", typeof(IEnumerable<ProductResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Products not found")]
    public async Task<IActionResult> GetAllProductsByProfileId(Guid profileId)
    {
        var getAllProductsByProfileIdQuery = new GetAllProductsByProfileId(profileId);
        
        var products = await productQueryService.Handle(getAllProductsByProfileIdQuery);
        
        if (products is null) return BadRequest();
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(productResources);
    }
    
    // GET ALL PRODUCTS BY PROFILE ID AND PRODUCT NAME ----------------------------------------------------------------
    [HttpGet("profile/{profileId}/productName/{productName}")]
    [SwaggerOperation("Get All Products by ProfileId and ProductName")]
    [SwaggerResponse(StatusCodes.Status200OK, "Products found", typeof(IEnumerable<ProductResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Products not found")]
    public async Task<IActionResult> GetAllProductsByProfileIdAndProductName(Guid profileId, string productName)
    {
        var getAllProductsByProfileIdAndProductNameQuery = new GetAllProductsByProfileIdAndProductName(profileId, productName);
        
        var products = await productQueryService.Handle(getAllProductsByProfileIdAndProductNameQuery);
        
        if (products is null) return BadRequest();
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(productResources);
    }
    
    // GET PRODUCT BY PRODUCT NAME -----------------------------------------------------------------------------------
    [HttpGet("productName/{productName}")]
    [SwaggerOperation("Get Product by ProductName")]
    [SwaggerResponse(StatusCodes.Status200OK, "Product found", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found")]
    public async Task<IActionResult> GetProductByProductName(string productName)
    {
        var getProductByProductNameQuery = new GetProductByProductNameQuery(productName);
        
        var product = await productQueryService.Handle(getProductByProductNameQuery);
        
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        
        return Ok(productResource);
    }
    
    // POST ----------------------------------------------------------------------------------------------------------
    [HttpPost ("profile/{profileId}")]
    [SwaggerOperation("Create Product by Profile")]
    [SwaggerResponse(StatusCodes.Status201Created, "Product created", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Product")]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductResource resource, Guid profileId)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var product = await productCommandService.Handle(createProductCommand, profileId);
        
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductByProductId), new { productId = product.Id }, productResource);
    }
    
    //DELETE-----------------------------------------------------------------------------------------------------------
    
    [HttpDelete("{productId}")]
    [SwaggerOperation("Delete Product by ProductId")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Product deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found")]
    public async Task<IActionResult> DeleteProductByProductId(int productId)
    {
        var deleteProductCommand = new DeleteProductCommand(productId);
        
        var product = await productCommandService.Handle(deleteProductCommand);
        
        //Mensaje personalizado: El producto no existe
        if (!product)
        {
            return NotFound( new { title = "Delete Product", message = "The product does not exist" });
        }
        
        return NoContent();
    }
    
    // UPDATE ---------------------------------------------------------------------------------------------------------
    
    [HttpPut("{productId}")]
    [SwaggerOperation("Update Product by ProductId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Product updated", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found")]
    public async Task<IActionResult> UpdateProductByProductId([FromBody] UpdateProductResource resource, int productId)
    {
        var updateProductCommand = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var product = await productCommandService.Handle(updateProductCommand, productId);
        
        if (product is null) return BadRequest(new {title ="Update Product", message = $"The product with {productId} does not exist"});
       
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        
        return Ok(productResource);
    }
    
    
    
    
}