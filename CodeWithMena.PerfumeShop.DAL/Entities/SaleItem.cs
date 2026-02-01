using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class SaleItem : BaseEntity<Guid>
    {
        public Guid SaleId { get; set; }
        public Guid? PerfumeOilId { get; set; }
        public Guid? BottleId { get; set; }
        public decimal? PerfumeOilGrams { get; set; }
        public required string NameSnapshot { get; set; }
        public string? ManufacturingCompanySnapshot { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public bool IsMixed { get; set; }

        public Sale Sale { get; set; } = null!;
        public Bottle? Bottle { get; set; }
        public PerfumeOil? PerfumeOil { get; set; }
        public MixedPerfume? MixedPerfume { get; set; }
    }
}
