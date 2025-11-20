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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}
