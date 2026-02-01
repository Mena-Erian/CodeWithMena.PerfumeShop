namespace CodeWithMena.PerfumeShop.PL.ViewModels.Reports
{
    public class DailyReportVm
    {
        public DailySummaryVm Summary { get; set; } = new();
        public List<InvoiceRowVm> Invoices { get; set; } = new();
    }
}
