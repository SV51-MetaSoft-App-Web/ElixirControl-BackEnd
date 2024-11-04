using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
         
      //===================================== 1. GONZALO Bounded Context ================================
         
         
      //===================================== END GONZALO Bounded Context ===============================
         
         
      //===================================== 2. GUSTAVO Bounded Context ================================
         
         
      //===================================== END GUSTAVO Bounded Context ===============================
         
         
      //===================================== 3. LUIS Bounded Context ===================================
      builder.Entity<Inventory>().HasKey(i => i.Id); 
      builder.Entity<Inventory>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd(); // ID autogenerado
        
      builder.Entity<Inventory>().Property(i => i.Name).IsRequired().HasMaxLength(100); 
      builder.Entity<Inventory>().Property(i => i.Type).IsRequired().HasMaxLength(50); 
      builder.Entity<Inventory>().Property(i => i.Unit).IsRequired().HasMaxLength(20); 
      builder.Entity<Inventory>().Property(i => i.Expiration).IsRequired(); 
      builder.Entity<Inventory>().Property(i => i.Supplier).IsRequired().HasMaxLength(100); 
      builder.Entity<Inventory>().Property(i => i.CostPerUnit).IsRequired(); 
      builder.Entity<Inventory>().Property(i => i.Quantity).IsRequired(); 
      builder.Entity<Inventory>().Property(i => i.LastUpdated).IsRequired(); 

         
      //===================================== END LUIS Bounded Context ==================================
         
         
      //===================================== 4. OSCAR Bounded Context ==================================
         
         
      //===================================== END OSCAR Bounded Context =================================
         
         
      //===================================== 5. VICENTE Bounded Context ================================
         
         
      //===================================== END VICENTE Bounded Context ===============================
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}