using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class DailySummary : BaseEntity<Guid>
    {
        public DateOnly Date { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetIncome { get; set; }
        public int InvoiceCount { get; set; }
    }
}
