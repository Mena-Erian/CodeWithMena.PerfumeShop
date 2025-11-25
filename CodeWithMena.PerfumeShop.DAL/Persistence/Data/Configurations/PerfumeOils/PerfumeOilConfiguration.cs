using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.PerfumeOils
{
    internal class PerfumeOilConfiguration : BasePerfumeConfiguration<PerfumeOil, Guid>
    {
        public override void Configure(EntityTypeBuilder<PerfumeOil> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.AvailableQuantityPerGram)
                .IsRequired(false);

            builder.Property(p => p.Code)
                .HasMaxLength(25)
                .IsRequired(false);

            builder.Property(p => p.FashionHouse)
                .HasMaxLength(25)
                .IsRequired(false);

            builder.Property(p => p.AlternativeName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.SupplierName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.ManufacturingCompany)
                .IsRequired(false)
                .HasConversion(
                    manufacturer => manufacturer.ToString(),
                    manufacturer => Enum.Parse<ManufacturingCompany>(manufacturer)
                ).HasMaxLength(50);
        }
    }
}
