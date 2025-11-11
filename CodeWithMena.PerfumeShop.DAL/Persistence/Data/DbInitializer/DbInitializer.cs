using CodeWithMena.PerfumeShop.DAL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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
            if (!dbContext.PerfumeOils.Any())
            {
                var perfumesOilData = File.ReadAllText("../CodeWithMena.PerfumeShop.DAL/Persistence/Data/Seeds/PerfumesOil.json");

                var perfumes = JsonSerializer.Deserialize<List<PerfumeOil>>(perfumesOilData, new JsonSerializerOptions()
                {
                    Converters = { new CustomPerfumesOilJsonConverter() }
                });

                if (perfumes?.Count > 0)
                {
                    dbContext.PerfumeOils.AddRange(perfumes);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
