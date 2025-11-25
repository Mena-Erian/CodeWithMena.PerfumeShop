using CodeWithMena.PerfumeShop.DAL.Common.Enums;
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
                //var perfumesOilData = File.ReadAllText("../CodeWithMena.PerfumeShop.DAL/Persistence/Data/Seeds/PerfumesOil.json");
                var perfumesOilData = " {\r\n   \"Id\": \"\",\r\n   \"CreatedBy\": \"MockDataGenerator\",\r\n   \"CreatedOn\": \"\",\r\n   \"LastModifiedBy\": \"MockDataGenerator\",\r\n   \"LastModifiedOn\": \"\",\r\n   \"Name\": \"Midnight Bloom\",\r\n   \"Description\": \"A captivating blend of floral notes, evoking a sense of wonder.\",\r\n   \"FragranceType\": \"Female\",\r\n   \"FragranceFamily\": \"Floral\",\r\n   \"RatingOfSale\": 5,\r\n   \"SupplierPrice\": 3.500,\r\n   \"SalePrice\": 5.00\r\n }";

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
            if (!dbContext.PerfumeOils.Where(p => p.ManufacturingCompany == ManufacturingCompany.ESSENCES_PERFUMES).Any())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Seeds", "EssencePerfumePriceList.csv");
                var essencePerfumesStr = File.ReadAllLines(path, Encoding.UTF8);

                var perfumes = new List<PerfumeOil>();

                foreach (var line in essencePerfumesStr.Skip(1))
                {
                    var parts = line.Split(",");
                    perfumes.Add(new PerfumeOil()
                    {
                        Id = Guid.NewGuid(),
                        CreatedBy = "ExcelFileDataSeeding",
                        LastModifiedBy = "",
                        Name = parts[4],
                        Description = "ESSENCES_PERFUMES,SeedingFromExcelFile",
                        FragranceFamily = null,
                        FragranceType = GetFragranceType(parts[5]),
                        PerfumePrice = new()
                        {
                            SupplierPrice = decimal.Parse(parts[1]) / 1000,
                            SalePrice = getAudiencePrice(decimal.Parse(parts[1]))
                        },
                        RatingOfSale = 1,
                        AlternativeName = parts[0],
                        AvailableQuantityPerGram = null,
                        Code = parts[2],
                        SupplierName = "",
                        FashionHouse = parts[3],
                        ManufacturingCompany = ManufacturingCompany.ESSENCES_PERFUMES
                    });
                }
                static FragranceType GetFragranceType(string fragranceType)
                {
                    var result = FragranceType.Other;
                    Enum.TryParse<FragranceType>(fragranceType, out result);
                    return result;
                }
                static decimal getAudiencePrice(decimal providerPrice)
                {
                    providerPrice = providerPrice / 1000;


                    if (providerPrice < 5)
                        return 5;
                    if (providerPrice >= 5 && providerPrice < 6)
                        return 6.5m;
                    if (providerPrice >= 6 && providerPrice < 7)
                        return 7.5m;
                    if (providerPrice >= 7 && providerPrice < 8)
                        return 9m;
                    if (providerPrice >= 8 && providerPrice < 9)
                        return 10m;

                    return 15m;
                }
                if (perfumes?.Count > 0)
                {
                    dbContext.PerfumeOils.AddRange(perfumes);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
