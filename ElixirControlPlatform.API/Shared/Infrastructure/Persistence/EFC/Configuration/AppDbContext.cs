using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
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
      builder.Entity<Client>().ToTable("Clients");
      builder.Entity<Client>().HasKey(f => f.Id);
      builder.Entity<Client>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Client>().Property(f => f.PersonName).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Dni).IsRequired();
      builder.Entity<Client>().Property(f => f.Email).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.BusinessName).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Phone).IsRequired();
      builder.Entity<Client>().Property(f => f.Address).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Country).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.City).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Ruc).IsRequired();
         
      //===================================== END GUSTAVO Bounded Context ===============================
         
         
      //===================================== 3. LUIS Bounded Context ===================================
         
         
      //===================================== END LUIS Bounded Context ==================================
         
         
      //===================================== 4. OSCAR Bounded Context ==================================
         
         
      //===================================== END OSCAR Bounded Context =================================
         
         
      //===================================== 5. VICENTE Bounded Context ================================
         
         
      //===================================== END VICENTE Bounded Context ===============================
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}