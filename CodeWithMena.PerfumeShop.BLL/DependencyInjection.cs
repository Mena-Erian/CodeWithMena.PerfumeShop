using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.BLL.Services;
using CodeWithMena.PerfumeShop.BLL.Services.Perfumes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPerfumeOilService, PerfumeOilService>();
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IReportService, ReportService>();

            return services;
        }
    }
}
