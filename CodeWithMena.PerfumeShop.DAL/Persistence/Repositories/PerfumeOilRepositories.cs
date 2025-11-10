using CodeWithMena.PerfumeShop.DAL.Common.Repositories;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using CodeWithMena.PerfumeShop.DAL.Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories
{
    internal class PerfumeOilRepositories(PerfumesShopDbContext dbContext) : BasePerfumeRepository<PerfumeOil, Guid>(dbContext),
        IPerfumeOilRepositories
    {

    }
}
