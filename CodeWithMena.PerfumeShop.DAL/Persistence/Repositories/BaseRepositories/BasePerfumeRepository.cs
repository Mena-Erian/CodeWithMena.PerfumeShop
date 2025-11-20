using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories.BaseRepositories
{
    internal class BasePerfumeRepository<TPerfumeEntity, TKey>(PerfumesShopDbContext dbContext) :
        BaseRepository<TPerfumeEntity, TKey>(dbContext),
        IBasePerfumeRepository<TPerfumeEntity, TKey>
        where TPerfumeEntity : BasePerfume<TPerfumeEntity, TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
