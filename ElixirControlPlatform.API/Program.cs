using ElixirControlPlatform.API.OrderRequest.Application.Internal.CommandServices;
using ElixirControlPlatform.API.OrderRequest.Application.Internal.QueryServices;
using ElixirControlPlatform.API.OrderRequest.Domain.Repositories;
using ElixirControlPlatform.API.OrderRequest.Domain.Services;
using ElixirControlPlatform.API.OrderRequest.Infrastructure.Persistence.EFC.Repositories;
using ElixirControlPlatform.API.Shared.Domain.Repositories;
using ElixirControlPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
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


//===================================== END GONZALO Bounded Context ===============================


//===================================== 2. GUSTAVO Bounded Context ================================


//===================================== END GUSTAVO Bounded Context ===============================


//===================================== 3. LUIS Bounded Context ===================================


//===================================== END LUIS Bounded Context ==================================


//===================================== 4. OSCAR Bounded Context ==================================
builder.Services.AddScoped<IOrderRequestsRepository, OrderRequestsRepository>();
builder.Services.AddScoped<IOrderRequestsCommandService, OrderRequestsCommandService>();
builder.Services.AddScoped<IOrderRequestsQueryService, OrderRequestsQueryService>();

//===================================== END OSCAR Bounded Context =================================


//===================================== 5. VICENTE Bounded Context ================================


//===================================== END VICENTE Bounded Context ===============================


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