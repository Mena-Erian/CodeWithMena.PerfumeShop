using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.AlcoholPrices
{
    internal class AlcoholPriceConfiguration : BaseEntityConfiguration<AlcoholPrice, Guid>
    {
        public override void Configure(EntityTypeBuilder<AlcoholPrice> builder)
        {
            base.Configure(builder);

            builder.ToTable("AlcoholPrices");

            builder.Property(a => a.PricePerMl)
                .HasPrecision(10, 3)
                .IsRequired();
            builder.Property(a => a.EffectiveFrom)
                .IsRequired();
        }
    }
}
