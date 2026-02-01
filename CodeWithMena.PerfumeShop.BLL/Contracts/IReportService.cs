using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.BLL.Contracts
{
    public interface IReportService
    {
        Task<DailySummary?> GetDailySummaryAsync(DateOnly date);
        Task<ICollection<DailySummary>> GetRangeSummaryAsync(DateOnly from, DateOnly to);
    }
}
