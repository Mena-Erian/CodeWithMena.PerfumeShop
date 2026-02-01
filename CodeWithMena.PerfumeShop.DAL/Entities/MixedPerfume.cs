using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class MixedPerfume : BaseEntity<Guid>
    {
        public Guid SaleItemId { get; set; }
        public required string MixCode { get; set; }

        public SaleItem SaleItem { get; set; } = null!;
        public ICollection<MixedPerfumeItem> MixedPerfumeItems { get; set; } = new List<MixedPerfumeItem>();
    }
}
