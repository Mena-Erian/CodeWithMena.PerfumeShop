using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class DailySummaryRepository(PerfumesShopDbContext dbContext) : IDailySummaryRepository
    {
        public async Task<DailySummary?> GetByDateAsync(DateOnly date)
            => await dbContext.DailySummaries.FirstOrDefaultAsync(ds => ds.Date == date);

        public async Task<ICollection<DailySummary>> GetRangeAsync(DateOnly from, DateOnly to)
            => await dbContext.DailySummaries
                .Where(ds => ds.Date >= from && ds.Date <= to)
                .OrderBy(ds => ds.Date)
                .ToListAsync();

        public async Task<int> AddOrUpdateAsync(DailySummary summary)
        {
            var existing = await dbContext.DailySummaries.FirstOrDefaultAsync(ds => ds.Date == summary.Date);
            if (existing != null)
            {
                existing.TotalSales = summary.TotalSales;
                existing.TotalDiscount = summary.TotalDiscount;
                existing.NetIncome = summary.NetIncome;
                existing.InvoiceCount = summary.InvoiceCount;
                existing.LastModifiedBy = summary.LastModifiedBy;
                dbContext.DailySummaries.Update(existing);
            }
            else
            {
                await dbContext.DailySummaries.AddAsync(summary);
            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
