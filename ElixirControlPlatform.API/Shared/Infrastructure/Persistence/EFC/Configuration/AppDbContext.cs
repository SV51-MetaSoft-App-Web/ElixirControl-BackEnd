using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;
using ElixirControlPlatform.API.InventoryManagement.Domain.Model.Aggregate;
using ElixirControlPlatform.API.OrderManagement.Domain.Model.Aggregate;
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
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      //---------------- CONFIGURATION BY BATCH ----------------
      builder.Entity<Batch>().HasKey(b => b.Id);
      builder.Entity<Batch>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Batch>().Property(b => b.VineyardCode).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.GrapeVariety).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.HarvestDate).IsRequired();
      builder.Entity<Batch>().Property(b => b.GrapeQuantity).IsRequired();
      builder.Entity<Batch>().Property(b => b.VineyardOrigin).IsRequired().HasMaxLength(50);
      builder.Entity<Batch>().Property(b => b.ProcessStartDate);
      builder.Entity<Batch>().Property(b => b.Status);
      
      
      //---------------- CONFIGURATION DE FERMENTATION ----------------
      builder.Entity<Fermentation>().HasKey(f => f.Id);
      builder.Entity<Fermentation>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Fermentation>().Property(f => f.BatchId).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.StartDate).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.EndDate);
      builder.Entity<Fermentation>().Property(f => f.AverageTemperature).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.InitialDensity).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.InitialPh).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.FinalDensity).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.FinalPh).IsRequired();
      builder.Entity<Fermentation>().Property(f => f.ResidualSugar).IsRequired();
      //---------------- Relación uno a uno con batch ----------------
      builder.Entity<Batch>()
         .HasOne(b => b.Fermentation);
      
      
      //---------------- CONFIGURATION DE CLARIFICATION ----------------
      builder.Entity<Clarification>().HasKey(c => c.Id);
      builder.Entity<Clarification>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Clarification>().Property(c => c.BatchId).IsRequired();
      builder.Entity<Clarification>().Property(c => c.ProductsUsed).IsRequired().HasMaxLength(50);
      builder.Entity<Clarification>().Property(c => c.ClarificationMethod).IsRequired().HasMaxLength(50);
      builder.Entity<Clarification>().Property(c => c.FiltrationDate);
      builder.Entity<Clarification>().Property(c => c.ClarityLevel).IsRequired();
      builder.Entity<Clarification>().Property(c => c.StartDate).IsRequired();
      builder.Entity<Clarification>().Property(c => c.EndDate).IsRequired();
      
      //---------------- Relación uno a uno con batch ----------------
      builder.Entity<Batch>()
         .HasOne(b => b.Clarification);
      
      
      //---------------- CONFIGURATION DE PRESSING ----------------
      builder.Entity<Pressing>().HasKey(p => p.Id);
      builder.Entity<Pressing>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Pressing>().Property(p => p.BatchId).IsRequired();
      builder.Entity<Pressing>().Property(p => p.PressingDate).IsRequired();
      builder.Entity<Pressing>().Property(p => p.MustVolume).IsRequired();
      builder.Entity<Pressing>().Property(p => p.PressType).IsRequired().HasMaxLength(50);
      builder.Entity<Pressing>().Property(p => p.AppliedPressure).IsRequired();
      
      //---------------- Relación uno a uno con batch ----------------
      builder.Entity<Batch>()
         .HasOne(b => b.Pressing);
      
      
      //---------------- CONFIGURATION DE AGING ----------------
      builder.Entity<Aging>().HasKey(a => a.Id);
      builder.Entity<Aging>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
      
      builder.Entity<Aging>().Property(a => a.BatchId).IsRequired();
      builder.Entity<Aging>().Property(a => a.BarrelType).IsRequired().HasMaxLength(50);
      builder.Entity<Aging>().Property(a => a.StartDate).IsRequired();
      builder.Entity<Aging>().Property(a => a.EndDate);
      builder.Entity<Aging>().Property(a => a.AgingDurationMonths).IsRequired();
      builder.Entity<Aging>().Property(a => a.InspectionsPerformed).IsRequired();
      builder.Entity<Aging>().Property(a => a.InspectionResult).IsRequired().HasMaxLength(50);
      
      //---------------- Relación uno a uno con batch ----------------
      builder.Entity<Batch>()
         .HasOne(b => b.Aging);
      
      //-----------------------------------------------------------------------------------------------
      //===================================== END GONZALO BOUNDED CONTEXT =============================
      //===============================================================================================
         
      
      //===============================================================================================
      //===================================== 2. GUSTAVO BOUNDED CONTEXT ==============================
      builder.Entity<Client>().HasKey(f => f.Id);
      builder.Entity<Client>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Client>().Property(f => f.PersonName).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Dni).IsRequired().HasMaxLength(20);
      builder.Entity<Client>().Property(f => f.Email).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.BusinessName).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Phone).IsRequired().HasMaxLength(20);
      builder.Entity<Client>().Property(f => f.Address).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Country).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.City).IsRequired().HasMaxLength(100);
      builder.Entity<Client>().Property(f => f.Ruc).IsRequired().HasMaxLength(20);
      //===================================== END GUSTAVO BOUNDED CONTEXT ==============================
      //================================================================================================
         
      
      //================================================================================================
      //===================================== 3. LUIS BOUNDED CONTEXT ==================================
      builder.Entity<Inventory>().HasKey(f => f.Id);
      builder.Entity<Inventory>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
   
      builder.Entity<Inventory>().Property(f => f.Name).IsRequired().HasMaxLength(100);
      builder.Entity<Inventory>().Property(f => f.Type).IsRequired().HasMaxLength(100);
      builder.Entity<Inventory>().Property(f => f.Unit).IsRequired().HasMaxLength(100);
      builder.Entity<Inventory>().Property(f => f.Expiration).IsRequired();
      builder.Entity<Inventory>().Property(f => f.Supplier).IsRequired().HasMaxLength(100);
      builder.Entity<Inventory>().Property(f => f.CostPerUnit).IsRequired();
      builder.Entity<Inventory>().Property(f => f.LastUpdated).IsRequired();
      builder.Entity<Inventory>().Property(f => f.Quantity).IsRequired();
      //===================================== END BOUNDED CONTEXT ======================================
      //================================================================================================
         
      
      //================================================================================================
      //===================================== 4. OSCAR BOUNDED CONTEXT =================================
         
         
      //===================================== END OSCAR BOUNDED CONTEXT ================================
      //================================================================================================
         
      
      //================================================================================================
      //===================================== 5. VICENTE BOUNDED CONTEXT ===============================
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
         
      //===================================== END VICENTE BOUNDED CONTEXT ===============================
      //=================================================================================================
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}