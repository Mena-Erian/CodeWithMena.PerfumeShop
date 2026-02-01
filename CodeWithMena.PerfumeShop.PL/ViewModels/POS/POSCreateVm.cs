using CodeWithMena.PerfumeShop.PL.ViewModels.Bottles;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.POS
{
    public class POSCreateVm
    {
        public List<BottleListVm> Bottles { get; set; } = new();
        public List<PerfumeOilListVm> PerfumeOils { get; set; } = new();
    }

    public class PerfumeOilListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ManufacturingCompany { get; set; }
        public decimal? SalePricePerGram { get; set; }
    }
}
