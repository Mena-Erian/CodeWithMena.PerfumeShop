using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.BLL.Contracts
{
    public interface IPerfumeOilService
    {
        Task<PerfumeOil?> GetPerfumeOilByIdAsync(Guid id);
        Task<ICollection<PerfumeOil>> GetAllPerfumesOilAsync();
        Task<ICollection<PerfumeOil>> FilterByFragrancyType(FragranceType fragranceType);

        Task<bool> CreatePerfumeOilAsync(PerfumeOil perfumeOil);
        Task<bool> UpdatePerfumeOilAsync(PerfumeOil perfumeOil);
        Task<bool> DeletePerfumeOilAsync(Guid id);
    }
}
