using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.Perfumes
{
    public class PerfumeOilEditDto
    {
        public required Guid Id { get; set; }

        [MinLength(2)]
        public required string Name { get; set; }

        public decimal? AvailableQuantityPerGram { get; set; }
        public string? Description { get; set; }
        public FragranceType FragranceType { get; set; }
        public FragranceFamily? FragranceFamily { get; set; }

        [Range(1, 10)]
        [Display(Name = "Rating Of Sale")]
        public int RatingOfSale { get; set; } = 0;

        public BasePerfumePrice? PerfumePrice { get; set; }
    }
}
