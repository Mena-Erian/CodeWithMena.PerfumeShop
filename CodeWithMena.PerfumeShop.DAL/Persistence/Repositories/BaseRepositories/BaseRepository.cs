using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Repositories.BaseRepositories
{
    internal class BaseRepository<TEntity, TKey>(PerfumesShopDbContext dbContext) : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        public DbSet<TEntity> dbSet { get; set; } = dbContext.Set<TEntity>();
        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteByIdAsync(TKey id)
        {
            var entity = await dbSet.FindAsync(id);

            if (entity != null && entity is { })
                dbSet.Remove(entity);

            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync() => await dbSet.ToListAsync();

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
            => await dbSet.FindAsync(id);

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
