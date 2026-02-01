using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class Sale : BaseEntity<Guid>
    {
        public required string InvoiceNumber { get; set; }
        public DateTime SaleDateTime { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
