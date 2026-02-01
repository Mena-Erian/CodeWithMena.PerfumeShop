using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class Bottle : BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public int SizeMl { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
