using CodeWithMena.PerfumeShop.DAL.Contracts;

namespace CodeWithMena.PerfumeShop.PL
{
    public static class InitializerExtensions
    {
        public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();


            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            
            dbInitializer.Initialize();
            dbInitializer.SeedData();

        }
    }
}
