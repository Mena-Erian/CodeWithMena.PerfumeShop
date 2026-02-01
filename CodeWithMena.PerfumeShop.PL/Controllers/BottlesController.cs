using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Bottles;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class BottlesController(IBottleRepository bottleRepo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bottles = await bottleRepo.GetAllAsync();
            var model = bottles.Select(b => new BottleListVm
            {
                Id = b.Id,
                Name = b.Name,
                SizeMl = b.SizeMl,
                SalePrice = b.SalePrice,
                IsActive = b.IsActive
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() => View(new BottleCreateDto());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BottleCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var bottle = new Bottle
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                SizeMl = dto.SizeMl,
                SalePrice = dto.SalePrice,
                IsActive = dto.IsActive,
                CreatedBy = "",
                LastModifiedBy = ""
            };
            await bottleRepo.AddAsync(bottle);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bottle = await bottleRepo.GetByIdAsync(id);
            if (bottle == null) return NotFound();

            var model = new BottleEditDto
            {
                Id = bottle.Id,
                Name = bottle.Name,
                SizeMl = bottle.SizeMl,
                SalePrice = bottle.SalePrice,
                IsActive = bottle.IsActive
            };
            TempData["BottleId"] = bottle.Id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BottleEditDto dto)
        {
            if (TempData["BottleId"]?.ToString() != dto.Id.ToString())
                return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            var bottle = await bottleRepo.GetByIdAsync(dto.Id);
            if (bottle == null) return NotFound();

            bottle.Name = dto.Name;
            bottle.SizeMl = dto.SizeMl;
            bottle.SalePrice = dto.SalePrice;
            bottle.IsActive = dto.IsActive;
            bottle.LastModifiedBy = "";
            await bottleRepo.UpdateAsync(bottle);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bottle = await bottleRepo.GetByIdAsync(id);
            if (bottle == null) return NotFound();
            await bottleRepo.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
