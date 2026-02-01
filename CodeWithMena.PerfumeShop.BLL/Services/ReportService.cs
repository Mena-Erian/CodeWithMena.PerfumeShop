using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.BLL.Services
{
    public class ReportService(
        IDailySummaryRepository dailySummaryRepo,
        ISaleRepository saleRepo) : IReportService
    {
        public async Task<DailySummary?> GetDailySummaryAsync(DateOnly date)
            => await dailySummaryRepo.GetByDateAsync(date);

        public async Task<ICollection<DailySummary>> GetRangeSummaryAsync(DateOnly from, DateOnly to)
            => await dailySummaryRepo.GetRangeAsync(from, to);

        public async Task<ICollection<Sale>> GetInvoicesForDayAsync(DateOnly date)
            => await saleRepo.GetByDateAsync(date);
    }
}
