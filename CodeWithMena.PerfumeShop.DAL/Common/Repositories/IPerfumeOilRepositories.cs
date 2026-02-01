using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base;
using CodeWithMena.PerfumeShop.DAL.Contracts;
using CodeWithMena.PerfumeShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface IPerfumeOilRepositories : IBasePerfumeRepository<PerfumeOil, Guid>
    {
        Task<ICollection<PerfumeOil>> FilterBy(FragranceType fragranceType);
        Task<ICollection<PerfumeOil>> FilterBy(FragranceFamily fragranceFamily);
        Task<ICollection<PerfumeOil>> FilterBy(BasePerfumePrice perfumePrice);
        Task<ICollection<PerfumeOil>> FilterBy(BasePerfumePrice perfumePrice, IEqualityComparer<BasePerfumePrice> equalityComparer);
        Task<ICollection<PerfumeOil>> FilterBy(Range ratingOfSale);
        Task<ICollection<PerfumeOil>> FilterBy(int ratingOfSale);
    }
}
