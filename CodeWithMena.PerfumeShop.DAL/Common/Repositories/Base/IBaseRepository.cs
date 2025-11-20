using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteByIdAsync(TKey id);
    }
}
