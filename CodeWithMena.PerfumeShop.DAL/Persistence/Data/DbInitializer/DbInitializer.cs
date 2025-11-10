using CodeWithMena.PerfumeShop.DAL.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.DbInitializer
{
    internal class DbInitializer(PerfumesShopDbContext dbContext) : IDbInitializer
    {
        public void Initialize()
        {
            if (dbContext.Database.GetPendingMigrations().Any())
                dbContext.Database.Migrate(); // UpdateAsync-Database
        }

        public void SeedData()
        {

        }
    }
}
