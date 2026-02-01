namespace CodeWithMena.PerfumeShop.PL.ViewModels.Bottles
{
    public class BottleListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SizeMl { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
