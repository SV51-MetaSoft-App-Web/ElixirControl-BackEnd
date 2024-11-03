using ElixirControlPlatform.API.OrderRequest.Domain.Model.Aggregate;
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


      //===================================== END LUIS Bounded Context ==================================


      //===================================== 4. OSCAR Bounded Context ==================================


      //===================================== END OSCAR Bounded Context =================================
      builder.Entity<OrderRequests>().HasKey(b => b.Id);
      builder.Entity<OrderRequests>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();

      builder.Entity<OrderRequests>().Property(b => b.Quantity).IsRequired();
      builder.Entity<OrderRequests>().Property(b => b.Price).IsRequired();
      builder.Entity<OrderRequests>().Property(b => b.Status);
      builder.Entity<OrderRequests>().Property(b => b.OrderNumber).IsRequired().HasMaxLength(50);
      builder.Entity<OrderRequests>().Property(b => b.OrderDate).IsRequired();
      builder.Entity<OrderRequests>().Property(b => b.TransportCondition).IsRequired().HasMaxLength(80);
      builder.Entity<OrderRequests>().Property(b => b.PaymentMethod).IsRequired().HasMaxLength(60);
      builder.Entity<OrderRequests>().Property(b => b.ConsumerPhone).IsRequired().HasMaxLength(50);
      builder.Entity<OrderRequests>().Property(b => b.ProducerPhone).IsRequired().HasMaxLength(50);
      builder.Entity<OrderRequests>().Property(b => b.PaymentTerms).IsRequired().HasMaxLength(80);
      builder.Entity<OrderRequests>().Property(b => b.Date).IsRequired().HasMaxLength(50);
      builder.Entity<OrderRequests>().Property(b => b.DeliveryDate).IsRequired().HasMaxLength(50);
      builder.Entity<OrderRequests>().Property(b => b.Type).IsRequired().HasMaxLength(50);
      
      
      
   //===================================== 5. VICENTE Bounded Context ================================
         
         
      //===================================== END VICENTE Bounded Context ===============================
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}