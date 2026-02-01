using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class AlcoholPriceRepository(PerfumesShopDbContext dbContext) : IAlcoholPriceRepository
    {
        public async Task<AlcoholPrice?> GetLatestAsync()
            => await dbContext.AlcoholPrices
                .OrderByDescending(a => a.EffectiveFrom)
                .FirstOrDefaultAsync();

        public async Task<AlcoholPrice?> GetByIdAsync(Guid id)
            => await dbContext.AlcoholPrices.FindAsync(id);

        public async Task<int> AddAsync(AlcoholPrice entity)
        {
            await dbContext.AlcoholPrices.AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(AlcoholPrice entity)
        {
            dbContext.AlcoholPrices.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
