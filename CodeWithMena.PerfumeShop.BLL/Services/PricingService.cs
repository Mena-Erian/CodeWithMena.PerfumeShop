using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeWithMena.PerfumeShop.BLL.Services
{
    public class PricingService(
        IPerfumeOilRepositories perfumeOilRepo,
        IBottleRepository bottleRepo,
        IAlcoholPriceRepository alcoholPriceRepo) : IPricingService
    {
        public async Task<decimal> CalculateUnitPriceAsync(Guid? perfumeOilId, Guid bottleId, decimal perfumeOilGrams = 0)
        {
            var bottle = await bottleRepo.GetByIdAsync(bottleId);
            var alcohol = await alcoholPriceRepo.GetLatestAsync();

            if (bottle == null)
                throw new InvalidOperationException("Bottle not found.");
            if (alcohol == null)
                throw new InvalidOperationException("No alcohol price configured.");

            decimal oilPart = 0m;
            if (perfumeOilId.HasValue && perfumeOilGrams > 0)
            {
                var perfume = await perfumeOilRepo.GetByIdAsync(perfumeOilId.Value);
                var salePricePerGram = perfume?.PerfumePrice?.SalePrice ?? 0m;
                oilPart = perfumeOilGrams * salePricePerGram;
            }

            var alcoholCost = alcohol.PricePerMl * bottle.SizeMl;
            return Math.Round(bottle.SalePrice + alcoholCost + oilPart, 2);
        }

        public async Task<decimal> CalculateMixedUnitPriceAsync(Guid bottleId, IReadOnlyList<(Guid PerfumeOilId, decimal MlUsed)> oilAmounts)
        {
            var bottle = await bottleRepo.GetByIdAsync(bottleId);
            var alcohol = await alcoholPriceRepo.GetLatestAsync();

            if (bottle == null)
                throw new InvalidOperationException("Bottle not found.");
            if (alcohol == null)
                throw new InvalidOperationException("No alcohol price configured.");

            decimal oilPart = 0m;
            foreach (var (perfumeOilId, mlUsed) in oilAmounts)
            {
                var perfume = await perfumeOilRepo.GetByIdAsync(perfumeOilId);
                var salePricePerGram = perfume?.PerfumePrice?.SalePrice ?? 0m;
                oilPart += salePricePerGram * mlUsed; // treating MlUsed as grams for price
            }

            var alcoholCost = alcohol.PricePerMl * bottle.SizeMl;
            return Math.Round(bottle.SalePrice + oilPart + alcoholCost, 2);
        }

        public decimal ApplyDiscount(decimal subtotal, decimal? discountPercent, decimal? discountAmount, out decimal totalAfterDiscount)
        {
            decimal discount = 0m;
            if (discountPercent.HasValue && discountPercent.Value > 0)
                discount = Math.Round(subtotal * (discountPercent.Value / 100m), 2);
            else if (discountAmount.HasValue && discountAmount.Value > 0)
                discount = Math.Min(discountAmount.Value, subtotal);

            totalAfterDiscount = Math.Round(subtotal - discount, 2);
            return discount;
        }
    }
}
