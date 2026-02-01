using System.ComponentModel.DataAnnotations;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.POS
{
    public class SaleEditVm
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime SaleDateTime { get; set; }
        public decimal Subtotal { get; set; }

        [Display(Name = "Discount %")]
        [Range(0, 100)]
        public decimal? DiscountPercent { get; set; }

        [Display(Name = "Discount (EGP)")]
        [Range(0, double.MaxValue)]
        public decimal? DiscountAmount { get; set; }

        [Display(Name = "Payment Method")]
        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public decimal TotalAfterDiscount { get; set; }
        public List<SaleItemLineVm> Items { get; set; } = new();
    }
}
