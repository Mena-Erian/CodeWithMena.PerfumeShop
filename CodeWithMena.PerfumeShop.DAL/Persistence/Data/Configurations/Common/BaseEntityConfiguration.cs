using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common
{
    internal class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(E => E.Id);
            builder.Property(D => D.CreatedBy).HasColumnType("varchar(50)");
            builder.Property(D => D.LastModifiedBy).HasColumnType("varchar(50)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDate()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETUTCDate()");
        }
    }
}
