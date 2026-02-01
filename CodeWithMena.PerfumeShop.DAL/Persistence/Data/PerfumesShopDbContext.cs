using CodeWithMena.PerfumeShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data
{
    internal class PerfumesShopDbContext(DbContextOptions<PerfumesShopDbContext> options) : DbContext(options)
    {
        public DbSet<PerfumeOil> PerfumeOils { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<AlcoholPrice> AlcoholPrices { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<MixedPerfume> MixedPerfumes { get; set; }
        public DbSet<MixedPerfumeItem> MixedPerfumeItems { get; set; }
        public DbSet<DailySummary> DailySummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}
