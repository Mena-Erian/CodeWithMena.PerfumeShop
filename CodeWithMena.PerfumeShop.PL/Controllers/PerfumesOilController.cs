using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.PL.ViewModels.Perfumes;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;

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

            var viewModel = new PerfumeOilEditDto()
            {
                Id = perfume.Id,
                Name = perfume.Name,
                Description = perfume.Description,
                PerfumePrice = perfume.PerfumePrice,
                AvailableQuantityPerGram = perfume.AvailableQuantityPerGram,
                FragranceType = perfume.FragranceType,
                FragranceFamily = perfume.FragranceFamily,
                RatingOfSale = perfume.RatingOfSale,

            };


            TempData["PerfumeOilId"] = perfume.Id;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PerfumeOilEditDto model)
        {
            if (model.Id.ToString() != TempData["PerfumeOilId"]?.ToString())
                return BadRequest();

            if (!ModelState.IsValid) return View(model);

            var perfume = await perfumeOilService.GetPerfumeOilByIdAsync(model.Id);

            if (perfume == null) return BadRequest();

            perfume.Name = model.Name;
            perfume.Description = model.Description;
            perfume.PerfumePrice = model.PerfumePrice;
            perfume.AvailableQuantityPerGram = model.AvailableQuantityPerGram;
            perfume.FragranceType = model.FragranceType;
            perfume.FragranceFamily = model.FragranceFamily;
            perfume.RatingOfSale = model.RatingOfSale;

            await perfumeOilService.UpdatePerfumeOilAsync(perfume);

            return RedirectToAction(actionName: nameof(Details), new { perfume.Id, viewName = "Details" });
        }


        [HttpGet]
        public async Task<IActionResult> Download()
        {
            var allPerfumes = await perfumeOilService.GetAllPerfumesOilAsync();

            return Json(allPerfumes);
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    bool isDeleted = await perfumeOilService.DeletePerfumeOilAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
