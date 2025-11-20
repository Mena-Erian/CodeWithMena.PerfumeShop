using CodeWithMena.PerfumeShop.DAL;
using CodeWithMena.PerfumeShop.BLL;
using System.Threading.Tasks;

namespace CodeWithMena.PerfumeShop.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Sevices
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            #endregion

            var app = builder.Build();

            #region Databaes Initialization

            await app.InitializeDatabaseAsync();

            #endregion

            #region Configure the HTTP request Pipline

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PerfumesOil}/{action=Index}/{id?}")
                .WithStaticAssets();

            #endregion

            app.Run();
        }
    }
}
