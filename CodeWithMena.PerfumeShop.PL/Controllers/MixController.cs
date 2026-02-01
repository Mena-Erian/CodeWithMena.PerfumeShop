using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.PL.ViewModels.Mix;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class MixController(IMixedPerfumeRepository mixedPerfumeRepo) : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> Details(string? code)
        {
            if (string.IsNullOrWhiteSpace(code)) return NotFound();
            code = code.Trim().ToUpperInvariant();

            var mixed = await mixedPerfumeRepo.GetByMixCodeWithDetailsAsync(code);
            if (mixed == null) return NotFound();

            var model = new MixedPerfumeDetailsVm
            {
                MixCode = mixed.MixCode,
                SaleItemName = mixed.SaleItem.NameSnapshot,
                BottleSize = mixed.SaleItem.Bottle != null ? mixed.SaleItem.Bottle.SizeMl + " ml" : "",
                InvoiceNumber = mixed.SaleItem.Sale?.InvoiceNumber ?? "",
                SaleDateTime = mixed.SaleItem.Sale?.SaleDateTime ?? DateTime.MinValue,
                Ingredients = mixed.MixedPerfumeItems.Select(mpi => new MixedPerfumeItemVm
                {
                    PerfumeOilName = mpi.PerfumeOil?.Name ?? "",
                    MlUsed = mpi.MlUsed
                }).ToList()
            };
            return View(model);
        }
    }
}
