using ElixirControlPlatform.API.CustomerManagement.Application.Internal.CommandServices;
using ElixirControlPlatform.API.CustomerManagement.Application.Internal.QueryServices;
using ElixirControlPlatform.API.CustomerManagement.Domain.Repositories;
using ElixirControlPlatform.API.CustomerManagement.Domain.Services;
using ElixirControlPlatform.API.CustomerManagement.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.IAM.Application.Internal.CommandServices;
using ElixirControlPlatform.API.IAM.Application.Internal.OutboundServices;
using ElixirControlPlatform.API.IAM.Application.Internal.QueryServices;
using ElixirControlPlatform.API.IAM.Domain.Repositories;
using ElixirControlPlatform.API.IAM.Domain.Services;
using ElixirControlPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using ElixirControlPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using ElixirControlPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using ElixirControlPlatform.API.InventoryManagement.Application.Internal.CommandServices;
using ElixirControlPlatform.API.InventoryManagement.Application.Internal.QueryServices;
using ElixirControlPlatform.API.InventoryManagement.Domain.Repositories;
using ElixirControlPlatform.API.InventoryManagement.Domain.Services;
using ElixirControlPlatform.API.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.OrderManagement.Application.Internal.CommandServices;
using ElixirControlPlatform.API.OrderManagement.Application.Internal.QueryServices;
using ElixirControlPlatform.API.OrderManagement.Domain.Repositories;
using ElixirControlPlatform.API.OrderManagement.Domain.Services;
using ElixirControlPlatform.API.OrderManagement.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.ProductManagement.Application.Internal.CommandServices;
using ElixirControlPlatform.API.ProductManagement.Application.Internal.QueryServices;
using ElixirControlPlatform.API.ProductManagement.Domain.Repositories;
using ElixirControlPlatform.API.ProductManagement.Domain.Services;
using ElixirControlPlatform.API.ProductManagement.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.Profiles.Application.Internal.CommandServices;
using ElixirControlPlatform.API.Profiles.Application.Internal.QueryServices;
using ElixirControlPlatform.API.Profiles.Domain.Repositories;
using ElixirControlPlatform.API.Profiles.Domain.Services;
using ElixirControlPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Pipeline.Middleware.Components;
using ElixirControlPlatform.API.WinemakingProcess.Application.Internal.CommandServices;
using ElixirControlPlatform.API.WinemakingProcess.Application.Internal.QueryServices;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Repositories;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Services;
using ElixirControlPlatform.API.WinemakingProcess.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



//===================================Add services to the container=====================================
builder.Services.AddControllers();
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}


builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {

        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});
//======================================================================================================

//======== Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle ========
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
//======================================================================================================

// Dependency Injection

//===================================== Shared Bounded Context ====================================
builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();
//=================================== END Shared Bounded Context ==================================


//===================================== 1. GONZALO Bounded Context ================================
//----------------- Batches -----------------
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<IBatchCommandService, BatchCommandService>();
builder.Services.AddScoped<IBatchQueryService, BatchQueryService>();

//----------------- Profiles -----------------

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

//----------------- Product -----------------

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();


//===================================== END GONZALO Bounded Context ===============================




//===================================== 2. GUSTAVO Bounded Context ================================
builder.Services.AddScoped<IClientCommandService, ClientCommandService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();
//===================================== END GUSTAVO Bounded Context ===============================




//===================================== 3. LUIS Bounded Context ===================================
builder.Services.AddScoped<IInventoryCommandService, InventoryCommandService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryQueryService, InventoryQueryService>();

//===================================== END LUIS Bounded Context ==================================




//===================================== 4. OSCAR Bounded Context ==================================

//===================================== END OSCAR Bounded Context =================================




//===================================== 5. VICENTE Bounded Context ================================
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
//===================================== END VICENTE Bounded Context ===============================


// IAM Bounded Context Dependency Injection Configuration

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// Common Exception Handling Middleware
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();


//==================== Verify if the database exists and create it if it doesn't ===================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}
//===============================================================================================


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();