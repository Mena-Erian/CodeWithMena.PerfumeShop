using CodeWithMena.PerfumeShop.DAL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PerfumesShopDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddScoped<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}
