using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.BLL.Contracts
{
    public class SaleItemInput
    {
        public Guid? PerfumeOilId { get; set; }
        public Guid? BottleId { get; set; }
        public decimal? PerfumeOilGrams { get; set; }
        public string NameSnapshot { get; set; } = string.Empty;
        public string? ManufacturingCompanySnapshot { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsMixed { get; set; }
        public bool IsManual { get; set; }
        public string? MixCode { get; set; }
        public List<MixedPerfumeItemInput>? MixedPerfumeItems { get; set; }
    }

    public class MixedPerfumeItemInput
    {
        public Guid PerfumeOilId { get; set; }
        public decimal MlUsed { get; set; }
    }

    public class CreateSaleInput
    {
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }
        public List<SaleItemInput> Items { get; set; } = new();
    }

    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(CreateSaleInput input);
        Task<Sale?> GetSaleByIdAsync(Guid id);
        Task<string> GenerateInvoiceNumberAsync();
        Task<string> GenerateMixCodeAsync();
    }
}
