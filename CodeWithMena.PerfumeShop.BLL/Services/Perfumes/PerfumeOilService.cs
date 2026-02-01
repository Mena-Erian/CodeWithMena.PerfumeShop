using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.BLL.Services.Perfumes
{
    public class PerfumeOilService(IPerfumeOilRepositories perfumeOilRepo) : IPerfumeOilService
    {
        public async Task<bool> CreatePerfumeOilAsync(PerfumeOil perfumeOil)
            => (await perfumeOilRepo.AddAsync(perfumeOil)) > 0;

        public async Task<bool> DeletePerfumeOilAsync(Guid id)
            => (await perfumeOilRepo.DeleteByIdAsync(id)) > 0;

        public async Task<ICollection<PerfumeOil>> FilterByFragrancyType(FragranceType fragranceType)
           => await perfumeOilRepo.FilterBy(fragranceType);
        public async Task<ICollection<PerfumeOil>> GetAllPerfumesOilAsync()
            => await perfumeOilRepo.GetAllAsync();

        public async Task<PerfumeOil?> GetPerfumeOilByIdAsync(Guid id)
            => await perfumeOilRepo.GetByIdAsync(id);

        public async Task<bool> UpdatePerfumeOilAsync(PerfumeOil perfumeOil)
            => (await perfumeOilRepo.UpdateAsync(perfumeOil)) > 0;
    }
}
