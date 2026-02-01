using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class SaleRepository(PerfumesShopDbContext dbContext) : ISaleRepository
    {
        public async Task<Sale?> GetByIdWithItemsAsync(Guid id)
            => await dbContext.Sales
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Bottle)
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.MixedPerfume)
                .ThenInclude(mp => mp!.MixedPerfumeItems)
                .ThenInclude(mpi => mpi.PerfumeOil)
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.PerfumeOil)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<int> AddAsync(Sale sale)
        {
            await dbContext.Sales.AddAsync(sale);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateSaleAndUpdateDailySummaryAsync(Sale sale, DailySummary? dailySummary)
        {
            await dbContext.Sales.AddAsync(sale);
            if (dailySummary != null)
            {
                var existing = await dbContext.DailySummaries.FirstOrDefaultAsync(ds => ds.Date == dailySummary.Date);
                if (existing != null)
                {
                    existing.TotalSales = dailySummary.TotalSales;
                    existing.TotalDiscount = dailySummary.TotalDiscount;
                    existing.NetIncome = dailySummary.NetIncome;
                    existing.InvoiceCount = dailySummary.InvoiceCount;
                    existing.LastModifiedBy = dailySummary.LastModifiedBy;
                    dbContext.DailySummaries.Update(existing);
                }
                else
                {
                    await dbContext.DailySummaries.AddAsync(dailySummary);
                }
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetNextInvoiceSequenceAsync(DateOnly date)
        {
            var prefix = date.ToString("yyyyMMdd");
            var lastNumber = await dbContext.Sales
                .Where(s => s.InvoiceNumber.StartsWith(prefix))
                .Select(s => s.InvoiceNumber)
                .ToListAsync();
            var maxSeq = lastNumber
                .Select(n => int.TryParse(n.Length > 8 ? n[8..] : "0", out var seq) ? seq : 0)
                .DefaultIfEmpty(0)
                .Max();
            return maxSeq + 1;
        }
    }
}
