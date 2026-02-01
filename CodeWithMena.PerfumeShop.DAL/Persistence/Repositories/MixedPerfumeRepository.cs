using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class MixedPerfumeRepository(PerfumesShopDbContext dbContext) : IMixedPerfumeRepository
    {
        public async Task<MixedPerfume?> GetByMixCodeWithDetailsAsync(string mixCode)
            => await dbContext.MixedPerfumes
                .Include(mp => mp.SaleItem)
                .ThenInclude(si => si.Sale)
                .Include(mp => mp.SaleItem)
                .ThenInclude(si => si.Bottle)
                .Include(mp => mp.MixedPerfumeItems)
                .ThenInclude(mpi => mpi.PerfumeOil)
                .FirstOrDefaultAsync(mp => mp.MixCode == mixCode);
    }
}
