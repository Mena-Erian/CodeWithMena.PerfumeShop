using CodeWithMena.PerfumeShop.DAL.Common.Entities;
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

        }
    }
}
