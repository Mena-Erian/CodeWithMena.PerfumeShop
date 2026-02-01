namespace CodeWithMena.PerfumeShop.PL.ViewModels.Mix
{
    public class MixedPerfumeDetailsVm
    {
        public string MixCode { get; set; } = string.Empty;
        public string SaleItemName { get; set; } = string.Empty;
        public string BottleSize { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime SaleDateTime { get; set; }
        public List<MixedPerfumeItemVm> Ingredients { get; set; } = new();
    }

    public class MixedPerfumeItemVm
    {
        public string PerfumeOilName { get; set; } = string.Empty;
        public decimal MlUsed { get; set; }
    }
}
