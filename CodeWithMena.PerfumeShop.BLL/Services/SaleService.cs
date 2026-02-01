using System.Security.Cryptography;
using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.BLL.Services
{
    public class SaleService(
        IPricingService pricingService,
        ISaleRepository saleRepo,
        IDailySummaryRepository dailySummaryRepo,
        IMixedPerfumeRepository mixedPerfumeRepo) : ISaleService
    {
        public async Task<string> GenerateInvoiceNumberAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var seq = await saleRepo.GetNextInvoiceSequenceAsync(today);
            return $"{today:yyyyMMdd}{seq:D4}";
        }

        public string GenerateMixCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var bytes = new byte[4];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
        }

        public async Task<Sale> CreateSaleAsync(CreateSaleInput input)
        {
            var invoiceNumber = await GenerateInvoiceNumberAsync();
            var saleDateTime = DateTime.UtcNow;
            const string auditUser = "System";

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = invoiceNumber,
                SaleDateTime = saleDateTime,
                Subtotal = 0m,
                DiscountPercent = input.DiscountPercent,
                DiscountAmount = input.DiscountAmount,
                TotalAfterDiscount = 0m,
                PaymentMethod = input.PaymentMethod,
                Notes = input.Notes,
                CreatedBy = auditUser,
                LastModifiedBy = auditUser
            };

            decimal subtotal = 0m;
            foreach (var itemInput in input.Items)
            {
                var lineTotal = itemInput.UnitPrice * itemInput.Quantity;
                subtotal += lineTotal;

                var saleItem = new SaleItem
                {
                    Id = Guid.NewGuid(),
                    SaleId = sale.Id,
                    PerfumeOilId = itemInput.IsManual ? null : itemInput.PerfumeOilId,
                    BottleId = itemInput.IsManual ? null : itemInput.BottleId,
                    PerfumeOilGrams = itemInput.PerfumeOilGrams,
                    NameSnapshot = itemInput.NameSnapshot,
                    ManufacturingCompanySnapshot = itemInput.ManufacturingCompanySnapshot,
                    Quantity = itemInput.Quantity,
                    UnitPrice = itemInput.UnitPrice,
                    LineTotal = lineTotal,
                    IsMixed = itemInput.IsMixed,
                    CreatedBy = auditUser,
                    LastModifiedBy = auditUser
                };

                if (itemInput.IsMixed && itemInput.MixedPerfumeItems != null && itemInput.MixedPerfumeItems.Count > 0)
                {
                    var mixCode = await EnsureUniqueMixCodeAsync();
                    var mixedPerfume = new MixedPerfume
                    {
                        Id = Guid.NewGuid(),
                        SaleItemId = saleItem.Id,
                        MixCode = mixCode,
                        CreatedBy = auditUser,
                        LastModifiedBy = auditUser
                    };
                    foreach (var mpi in itemInput.MixedPerfumeItems)
                    {
                        mixedPerfume.MixedPerfumeItems.Add(new MixedPerfumeItem
                        {
                            Id = Guid.NewGuid(),
                            MixedPerfumeId = mixedPerfume.Id,
                            PerfumeOilId = mpi.PerfumeOilId,
                            MlUsed = mpi.MlUsed,
                            CreatedBy = auditUser,
                            LastModifiedBy = auditUser
                        });
                    }
                    saleItem.MixedPerfume = mixedPerfume;
                }

                sale.SaleItems.Add(saleItem);
            }

            decimal temp = decimal.Zero;
            sale.Subtotal = Math.Round(subtotal, 2);
            pricingService.ApplyDiscount(sale.Subtotal, input.DiscountPercent, input.DiscountAmount, totalAfterDiscount: out temp);
            sale.TotalAfterDiscount = temp;

            var date = DateOnly.FromDateTime(saleDateTime);
            var existingSummary = await dailySummaryRepo.GetByDateAsync(date);
            DailySummary dailySummary;
            if (existingSummary != null)
            {
                existingSummary.TotalSales += sale.Subtotal;
                existingSummary.TotalDiscount += sale.Subtotal - sale.TotalAfterDiscount;
                existingSummary.NetIncome += sale.TotalAfterDiscount;
                existingSummary.InvoiceCount += 1;
                existingSummary.LastModifiedBy = auditUser;
                dailySummary = existingSummary;
            }
            else
            {
                dailySummary = new DailySummary
                {
                    Id = Guid.NewGuid(),
                    Date = date,
                    TotalSales = sale.Subtotal,
                    TotalDiscount = sale.Subtotal - sale.TotalAfterDiscount,
                    NetIncome = sale.TotalAfterDiscount,
                    InvoiceCount = 1,
                    CreatedBy = auditUser,
                    LastModifiedBy = auditUser
                };
            }

            await saleRepo.CreateSaleAndUpdateDailySummaryAsync(sale, dailySummary);
            return sale;
        }

        private async Task<string> EnsureUniqueMixCodeAsync()
        {
            const int maxAttempts = 10;
            for (var i = 0; i < maxAttempts; i++)
            {
                var code = GenerateMixCode();
                var existing = await mixedPerfumeRepo.GetByMixCodeWithDetailsAsync(code);
                if (existing == null)
                    return code;
            }
            return GenerateMixCode();
        }

        public async Task<string> GenerateMixCodeAsync() => await Task.FromResult(GenerateMixCode());

        public async Task<Sale?> GetSaleByIdAsync(Guid id) => await saleRepo.GetByIdWithItemsAsync(id);
    }
}
