using CodeWithMena.PerfumeShop.BLL.Contracts;
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

        public IActionResult Create()
        {
            return View();
        }

    }
}
