namespace CodeWithMena.PerfumeShop.PL.ViewModels.Reports
{
    public class DailySummaryVm
    {
        public DateOnly Date { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetIncome { get; set; }
        public int InvoiceCount { get; set; }
    }
}
