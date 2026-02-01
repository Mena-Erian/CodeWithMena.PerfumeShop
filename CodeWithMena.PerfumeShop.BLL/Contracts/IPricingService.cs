namespace CodeWithMena.PerfumeShop.BLL.Contracts
{
    public interface IPricingService
    {
        /// <summary>
        /// Calculates unit price: Bottle.SalePrice + (AlcoholPrice.PricePerMl * Bottle.SizeMl) + (perfumeOilGrams * PerfumeOil.SalePricePerGram).
        /// When perfumeOilId is null or perfumeOilGrams is 0, oil part is 0.
        /// </summary>
        Task<decimal> CalculateUnitPriceAsync(Guid? perfumeOilId, Guid bottleId, decimal perfumeOilGrams = 0);

        /// <summary>
        /// Calculates unit price for a mixed perfume (sum of oil contributions + bottle + alcohol).
        /// </summary>
        Task<decimal> CalculateMixedUnitPriceAsync(Guid bottleId, IReadOnlyList<(Guid PerfumeOilId, decimal MlUsed)> oilAmounts);

        /// <summary>
        /// Applies discount to subtotal. Either percent or fixed amount (EGP).
        /// </summary>
        decimal ApplyDiscount(decimal subtotal, decimal? discountPercent, decimal? discountAmount, out decimal totalAfterDiscount);
    }
}
