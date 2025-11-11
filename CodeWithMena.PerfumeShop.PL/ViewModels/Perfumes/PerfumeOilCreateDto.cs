using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.Perfumes
{
    public class PerfumeOilCreateDto
    {
        //public required TKey Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public FragranceType FragranceType { get; set; }
        public FragranceFamily? FragranceFamily { get; set; }
        public int RatingOfSale { get; set; }
        public BasePerfumePrice? PerfumePrice { get; set; }



        public required string CreatedBy { get; set; } = string.Empty;
        //public DateTime CreatedOn { get; set; }
        public required string LastModifiedBy { get; set; } = string.Empty;
        //public DateTime LastModifiedOn { get; set; }

    }
}
