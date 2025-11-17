using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Perfumes;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class PerfumesOilController(IPerfumeOilService perfumeOilService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await perfumeOilService.GetAllPerfumesOilAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PerfumeOilCreateDto perfumeOil)
        {
            if (!ModelState.IsValid) return View(perfumeOil);

            await perfumeOilService.CreatePerfumeOilAsync(new PerfumeOil()
            {
                Id = Guid.NewGuid(),
                Name = perfumeOil.Name,
                PerfumePrice = perfumeOil.PerfumePrice,
                AvailableQuantityPerGram = perfumeOil.AvailableQuantityPerGram,
                CreatedBy = "",
                LastModifiedBy = "",
                Description = perfumeOil.Description,
                FragranceType = perfumeOil.FragranceType,
                FragranceFamily = perfumeOil.FragranceFamily,
                RatingOfSale = perfumeOil.RatingOfSale
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var perfume = await perfumeOilService.GetPerfumeOilByIdAsync(id);

            if (perfume == null) return BadRequest();

            return View(perfume);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var perfume = await perfumeOilService.GetPerfumeOilByIdAsync(id);

            if (perfume == null) return BadRequest();

            return View(perfume);
        }
        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var allPerfumes = await perfumeOilService.GetAllPerfumesOilAsync();

            return Json(allPerfumes);
        }

    }
}
