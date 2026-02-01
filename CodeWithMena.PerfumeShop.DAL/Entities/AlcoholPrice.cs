using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class AlcoholPrice : BaseEntity<Guid>
    {
        public decimal PricePerMl { get; set; }
        public DateTime EffectiveFrom { get; set; }
    }
}
