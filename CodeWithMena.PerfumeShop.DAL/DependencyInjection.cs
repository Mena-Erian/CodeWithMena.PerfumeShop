using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.DbInitializer;
using CodeWithMena.PerfumeShop.DAL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeWithMena.PerfumeShop.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PerfumesShopDbContext>(optionBuilder =>
            {                                                                   
                optionBuilder.UseSqlServer(configuration.GetConnectionString("DevConnection"));
                //optionBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                //optionBuilder.UseSqlServer(configuration.GetConnectionString("SqlRemoteConnection"));
            });

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddScoped<IPerfumeOilRepositories, PerfumeOilRepositories>();
            services.AddScoped<IBottleRepository, BottleRepository>();
            services.AddScoped<IAlcoholPriceRepository, AlcoholPriceRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IDailySummaryRepository, DailySummaryRepository>();
            services.AddScoped<IMixedPerfumeRepository, MixedPerfumeRepository>();

            return services;
        }
    }
}
