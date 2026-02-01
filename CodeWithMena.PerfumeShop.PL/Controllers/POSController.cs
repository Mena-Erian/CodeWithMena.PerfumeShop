using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Bottles;
using CodeWithMena.PerfumeShop.PL.ViewModels.POS;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class POSController(
        IPricingService pricingService,
        ISaleService saleService,
        IBottleRepository bottleRepo,
        IPerfumeOilRepositories perfumeOilRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetUnitPrice(
            [FromQuery] Guid? perfumeOilId,
            [FromQuery] Guid bottleId,
            [FromQuery] decimal grams = 0)
        {
            try
            {
                var price = await pricingService.CalculateUnitPriceAsync(perfumeOilId, bottleId, grams);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bottles = await bottleRepo.GetActiveBottlesAsync();
            var perfumes = await perfumeOilRepo.GetAllAsync();
            var model = new POSCreateVm
            {
                Bottles = bottles.Select(b => new BottleListVm
                {
                    Id = b.Id,
                    Name = b.Name,
                    SizeMl = b.SizeMl,
                    SalePrice = b.SalePrice,
                    IsActive = b.IsActive
                }).ToList(),
                PerfumeOils = perfumes.Select(p => new PerfumeOilListVm
                {
                    Id = p.Id,
                    Name = p.Name,
                    ManufacturingCompany = p.ManufacturingCompany?.ToString(),
                    SalePricePerGram = p.PerfumePrice?.SalePrice
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateSaleRequest? request)
        {
            if (request?.Items == null || request.Items.Count == 0)
                return BadRequest("At least one item is required.");

            var input = new CreateSaleInput
            {
                DiscountPercent = request.DiscountPercent,
                DiscountAmount = request.DiscountAmount,
                PaymentMethod = request.PaymentMethod,
                Notes = request.Notes,
                Items = request.Items.Select(i => new SaleItemInput
                {
                    PerfumeOilId = i.PerfumeOilId,
                    BottleId = i.BottleId,
                    PerfumeOilGrams = i.PerfumeOilGrams,
                    NameSnapshot = i.NameSnapshot,
                    ManufacturingCompanySnapshot = i.ManufacturingCompanySnapshot,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    IsMixed = i.IsMixed,
                    IsManual = i.IsManual,
                    MixedPerfumeItems = i.MixedPerfumeItems?.Select(m => new MixedPerfumeItemInput
                    {
                        PerfumeOilId = m.PerfumeOilId,
                        MlUsed = m.MlUsed
                    }).ToList()
                }).ToList()
            };

            var sale = await saleService.CreateSaleAsync(input);
            return Ok(new { saleId = sale.Id, invoiceNumber = sale.InvoiceNumber });
        }

        [HttpGet]
        public async Task<IActionResult> Invoice(Guid id)
        {
            var sale = await saleService.GetSaleByIdAsync(id);
            if (sale == null) return NotFound();

            var model = POSControllerHelpers.MapToInvoiceVm(sale);
            return View(model);
        }
    }

    public static class POSControllerHelpers
    {
        public static SaleInvoiceVm MapToInvoiceVm(Sale sale)
        {
            return new SaleInvoiceVm
            {
                Id = sale.Id,
                InvoiceNumber = sale.InvoiceNumber,
                SaleDateTime = sale.SaleDateTime,
                Subtotal = sale.Subtotal,
                DiscountPercent = sale.DiscountPercent,
                DiscountAmount = sale.DiscountAmount,
                TotalAfterDiscount = sale.TotalAfterDiscount,
                PaymentMethod = sale.PaymentMethod,
                Notes = sale.Notes,
                Items = sale.SaleItems.Select(si => new SaleItemLineVm
                {
                    NameSnapshot = si.NameSnapshot,
                    ManufacturingCompanySnapshot = si.ManufacturingCompanySnapshot,
                    Quantity = si.Quantity,
                    UnitPrice = si.UnitPrice,
                    LineTotal = si.LineTotal,
                    IsMixed = si.IsMixed,
                    MixCode = si.MixedPerfume?.MixCode,
                    BottleSize = si.Bottle != null ? si.Bottle.SizeMl + " ml" : (si.BottleId == null ? "—" : "")
                }).ToList()
            };
        }
    }

    public class CreateSaleRequest
    {
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Notes { get; set; }
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }

    public class CreateSaleItemRequest
    {
        public Guid? PerfumeOilId { get; set; }
        public Guid? BottleId { get; set; }
        public decimal? PerfumeOilGrams { get; set; }
        public string NameSnapshot { get; set; } = string.Empty;
        public string? ManufacturingCompanySnapshot { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsMixed { get; set; }
        public bool IsManual { get; set; }
        public List<MixedPerfumeItemRequest>? MixedPerfumeItems { get; set; }
    }

    public class MixedPerfumeItemRequest
    {
        public Guid PerfumeOilId { get; set; }
        public decimal MlUsed { get; set; }
    }
}
