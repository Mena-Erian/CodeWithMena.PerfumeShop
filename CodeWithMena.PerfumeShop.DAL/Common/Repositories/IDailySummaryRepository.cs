using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface IDailySummaryRepository
    {
        Task<DailySummary?> GetByDateAsync(DateOnly date);
        Task<ICollection<DailySummary>> GetRangeAsync(DateOnly from, DateOnly to);
        Task<int> AddOrUpdateAsync(DailySummary summary);
    }
}
