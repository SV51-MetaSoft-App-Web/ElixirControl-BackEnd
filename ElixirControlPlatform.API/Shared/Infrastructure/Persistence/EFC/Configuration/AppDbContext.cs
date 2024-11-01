using ElixirControlPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Aggregate;
using ElixirControlPlatform.API.WinemakingProcess.Domain.Model.Entities;
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
      // Configuration by Batch
      builder.Entity<Batch>().HasKey(b => b.Id);
      builder.Entity<Batch>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Batch>().Property(b => b.VineyardCode).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.GrapeVariety).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.HarvestDate).IsRequired();
      builder.Entity<Batch>().Property(b => b.GrapeQuantity).IsRequired();
      builder.Entity<Batch>().Property(b => b.VineyardOrigin).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.ProcessStartDate).IsRequired();
      
      //---------------------------------------------------------------------------------------------------
      // Configuration de Fermentation
      builder.Entity<Fermentation>().HasKey(f => f.Id);
      builder.Entity<Fermentation>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Fermentation>().Property(f => f.BatchId).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.StartDate).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.EndDate).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.AverageTemperature).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.InitialDensity).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.InitialPh).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.FinalDensity).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.FinalPh).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.ResidualSugar).IsRequired();
      
      
      
      // Configuración de la relación uno a uno
      builder.Entity<Batch>()
         .HasOne(b => b.Fermentation);
      
      //===================================== END GONZALO Bounded Context ===============================
         
         
      //===================================== 2. GUSTAVO Bounded Context ================================
         
         
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