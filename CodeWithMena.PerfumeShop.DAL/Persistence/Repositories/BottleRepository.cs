using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using CodeWithMena.PerfumeShop.DAL.Persistence.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class BottleRepository(PerfumesShopDbContext dbContext) : BaseRepository<Bottle, Guid>(dbContext), IBottleRepository
    {
        public async Task<ICollection<Bottle>> GetActiveBottlesAsync()
            => await dbSet.Where(b => b.IsActive).OrderBy(b => b.SizeMl).ToListAsync();
    }
}
