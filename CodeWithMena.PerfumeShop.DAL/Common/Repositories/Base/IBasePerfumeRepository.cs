using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base
{
    internal interface IBasePerfumeRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BasePerfume<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
