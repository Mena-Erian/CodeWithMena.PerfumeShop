using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale?> GetByIdWithItemsAsync(Guid id);
        Task<ICollection<Sale>> GetByDateAsync(DateOnly date);
        Task<int> AddAsync(Sale sale);
        Task<int> UpdateAsync(Sale sale);
        /// <summary>
        /// Adds sale (with items) and optionally upserts daily summary in one transaction.
        /// </summary>
        Task<int> CreateSaleAndUpdateDailySummaryAsync(Sale sale, DailySummary? dailySummary);
        Task<int> GetNextInvoiceSequenceAsync(DateOnly date);
    }
}
