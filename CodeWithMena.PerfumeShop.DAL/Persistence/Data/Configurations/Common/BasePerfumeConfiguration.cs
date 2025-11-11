using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common
{
    internal class BasePerfumeConfiguration<TPerfumeEntity, TKey>
        : BaseEntityConfiguration<TPerfumeEntity, TKey>
        where TPerfumeEntity : BasePerfume<TPerfumeEntity, TKey>
        where TKey : IEquatable<TKey>
    {

        public override void Configure(EntityTypeBuilder<TPerfumeEntity> builder)
        {
            base.Configure(builder);

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.FragranceType)
                .IsRequired()
                .HasConversion(
                fregType => fregType.ToString(),
                fregType => Enum.Parse<FragranceType>(fregType)
                ).HasMaxLength(100);

            builder.Property(p => p.FragranceFamily)
                .IsRequired(false)
                .HasConversion(
                    fregFamily => fregFamily.ToString(),
                    fregFamily => Enum.Parse<FragranceFamily>(fregFamily)
                ).HasMaxLength(100);

            builder.Property(p => p.RatingOfSale)
                   .IsRequired()
                   //.HasAnnotation("Range", new RangeAttribute(0, 10))
                   ;

            builder.OwnsOne(p => p.PerfumePrice, price =>
            {
                price.Property(p => p.SupplierPrice)
                     .HasPrecision(10, 3)
                     .IsRequired(false)
                     .HasColumnName("SupplierPrice");

                price.Property(p => p.SalePrice)
                     .HasPrecision(10, 3)
                     .IsRequired(false)
                     .HasColumnName("SalePrice");

            });

        }
    }
}
