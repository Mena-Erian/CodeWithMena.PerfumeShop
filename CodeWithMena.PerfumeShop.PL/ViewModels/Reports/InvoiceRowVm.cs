namespace CodeWithMena.PerfumeShop.PL.ViewModels.Reports
{
    public class InvoiceRowVm
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime SaleDateTime { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public string? PaymentMethod { get; set; }
        public int ItemCount { get; set; }
    }
}
