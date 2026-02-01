using CodeWithMena.PerfumeShop.DAL.Common.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class MixedPerfumeItem : BaseEntity<Guid>
    {
        public Guid MixedPerfumeId { get; set; }
        public Guid PerfumeOilId { get; set; }
        public decimal MlUsed { get; set; }

        public MixedPerfume MixedPerfume { get; set; } = null!;
        public PerfumeOil PerfumeOil { get; set; } = null!;
    }
}
