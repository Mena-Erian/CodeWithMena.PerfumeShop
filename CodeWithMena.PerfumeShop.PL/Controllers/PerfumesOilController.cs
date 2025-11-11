using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Perfumes;
using Microsoft.AspNetCore.Mvc;

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
                CreatedBy = perfumeOil.CreatedBy,
                LastModifiedBy = perfumeOil.LastModifiedBy,
                Description = perfumeOil.Description,
                FragranceType = perfumeOil.FragranceType
            });

            return RedirectToAction(nameof(Index));
        }

    }
}
