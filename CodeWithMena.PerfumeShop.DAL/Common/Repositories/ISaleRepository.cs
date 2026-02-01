using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale?> GetByIdWithItemsAsync(Guid id);
        Task<int> AddAsync(Sale sale);
        /// <summary>
        /// Adds sale (with items) and optionally upserts daily summary in one transaction.
        /// </summary>
        Task<int> CreateSaleAndUpdateDailySummaryAsync(Sale sale, DailySummary? dailySummary);
        Task<int> GetNextInvoiceSequenceAsync(DateOnly date);
    }
}
