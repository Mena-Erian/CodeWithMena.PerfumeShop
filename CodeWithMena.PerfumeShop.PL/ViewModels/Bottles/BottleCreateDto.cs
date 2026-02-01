using System.ComponentModel.DataAnnotations;

namespace CodeWithMena.PerfumeShop.PL.ViewModels.Bottles
{
    public class BottleCreateDto
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Bottle Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Size (ml)")]
        [Range(1, 1000)]
        public int SizeMl { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        [Range(0, double.MaxValue)]
        public decimal SalePrice { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
    }
}
