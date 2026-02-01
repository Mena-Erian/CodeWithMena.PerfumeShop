using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Settings;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class SettingsController(IAlcoholPriceRepository alcoholPriceRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AlcoholPrice()
        {
            var latest = await alcoholPriceRepo.GetLatestAsync();
            var model = latest == null
                ? new AlcoholPriceVm { EffectiveFrom = DateTime.UtcNow }
                : new AlcoholPriceVm
                {
                    Id = latest.Id,
                    PricePerMl = latest.PricePerMl,
                    EffectiveFrom = latest.EffectiveFrom
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlcoholPrice(AlcoholPriceVm model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id.HasValue)
            {
                var existing = await alcoholPriceRepo.GetByIdAsync(model.Id.Value);
                if (existing != null)
                {
                    existing.PricePerMl = model.PricePerMl;
                    existing.EffectiveFrom = model.EffectiveFrom;
                    existing.LastModifiedBy = "";
                    await alcoholPriceRepo.UpdateAsync(existing);
                }
            }
            else
            {
                var entity = new AlcoholPrice
                {
                    Id = Guid.NewGuid(),
                    PricePerMl = model.PricePerMl,
                    EffectiveFrom = model.EffectiveFrom,
                    CreatedBy = "",
                    LastModifiedBy = ""
                };
                await alcoholPriceRepo.AddAsync(entity);
            }
            return RedirectToAction(nameof(AlcoholPrice));
        }
    }
}
