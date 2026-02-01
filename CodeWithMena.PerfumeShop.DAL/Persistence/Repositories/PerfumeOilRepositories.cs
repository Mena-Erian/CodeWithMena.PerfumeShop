using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using CodeWithMena.PerfumeShop.DAL.Persistence.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class PerfumeOilRepositories(PerfumesShopDbContext dbContext) : BasePerfumeRepository<PerfumeOil, Guid>(dbContext),
        IPerfumeOilRepositories
    {
        public async Task<ICollection<PerfumeOil>> FilterBy(FragranceType fragranceType) 
            => await dbSet.Where(p => p.FragranceType == fragranceType).ToListAsync();

        public async Task<ICollection<PerfumeOil>> FilterBy(FragranceFamily fragranceFamily) 
            => await dbSet.Where(p => p.FragranceFamily == fragranceFamily).ToListAsync();

        public async Task<ICollection<PerfumeOil>> FilterBy(BasePerfumePrice perfumePrice)
            => await dbSet.Where(p => p.PerfumePrice == perfumePrice).ToListAsync();
        public async Task<ICollection<PerfumeOil>> FilterBy(BasePerfumePrice perfumePrice, IEqualityComparer<BasePerfumePrice> equalityComparer)
            => await dbSet.Where(p => equalityComparer.Equals(p.PerfumePrice, perfumePrice)).ToListAsync();

        public async Task<ICollection<PerfumeOil>> FilterBy(Range ratingOfSale)
            => await dbSet.Where(p => (p.RatingOfSale <= ratingOfSale.Start.Value) && (p.RatingOfSale >= ratingOfSale.End.Value)).ToListAsync();

        public async Task<ICollection<PerfumeOil>> FilterBy(int ratingOfSale) 
            => await dbSet.Where(p => p.RatingOfSale == ratingOfSale).ToListAsync();
    }
}
