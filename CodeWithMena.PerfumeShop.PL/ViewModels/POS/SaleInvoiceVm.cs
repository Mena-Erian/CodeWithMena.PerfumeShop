namespace CodeWithMena.PerfumeShop.PL.ViewModels.POS
{
    public class SaleInvoiceVm
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime SaleDateTime { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }
        public List<SaleItemLineVm> Items { get; set; } = new();
    }

    public class SaleItemLineVm
    {
        public string NameSnapshot { get; set; } = string.Empty;
        public string? ManufacturingCompanySnapshot { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public bool IsMixed { get; set; }
        public string? MixCode { get; set; }
        public string BottleSize { get; set; } = string.Empty;
    }
}
