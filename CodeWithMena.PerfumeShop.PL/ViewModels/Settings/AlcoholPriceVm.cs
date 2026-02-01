using System.ComponentModel.DataAnnotations;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.Settings
{
    public class AlcoholPriceVm
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Price per ml (EGP)")]
        [Range(0, double.MaxValue)]
        public decimal PricePerMl { get; set; }

        [Required]
        [Display(Name = "Effective From")]
        [DataType(DataType.DateTime)]
        public DateTime EffectiveFrom { get; set; } = DateTime.UtcNow;
    }
}
