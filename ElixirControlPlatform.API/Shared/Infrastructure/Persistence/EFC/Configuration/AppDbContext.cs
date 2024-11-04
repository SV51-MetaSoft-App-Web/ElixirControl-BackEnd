using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
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
         
         
      //===================================== END LUIS Bounded Context ==================================
         
         
      //===================================== 4. OSCAR Bounded Context ==================================
         
         
      //===================================== END OSCAR Bounded Context =================================
         
         
      //===================================== 5. VICENTE Bounded Context ================================
         builder.Entity<Order>().HasKey(o => o.Id);
         builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
         builder.Entity<Order>().Property(o => o.BusinessName).IsRequired().HasMaxLength(50);
         builder.Entity<Order>().Property(o => o.RequestedDate).IsRequired();
         builder.Entity<Order>().Property(o => o.Quantity).IsRequired();
         builder.Entity<Order>().Property(o => o.Phone).IsRequired();
         builder.Entity<Order>().Property(o => o.Status).IsRequired();
         builder.Entity<Order>().Property(o => o.ContactName).IsRequired();
         builder.Entity<Order>().Property(o => o.ProductName).IsRequired();
         builder.Entity<Order>().Property(o => o.TransportCondition).IsRequired();
         builder.Entity<Order>().Property(o => o.PaymentTerms).IsRequired();
         builder.Entity<Order>().Property(o => o.ContactName).IsRequired();
         builder.Entity<Order>().Property(o => o.Address).IsRequired();
         builder.Entity<Order>().Property(o => o.Email).IsRequired();
         builder.Entity<Order>().Property(o => o.Ruc).IsRequired();
         builder.Entity<Order>().Property(o => o.WineType).IsRequired();
         builder.Entity<Order>().Property(o => o.PaymentMethod).IsRequired();
         builder.Entity<Order>().Property(o => o.DeliveryDate).IsRequired();
         
         
      //===================================== END VICENTE Bounded Context ===============================
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}