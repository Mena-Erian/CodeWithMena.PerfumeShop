using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.SaleItems
{
    internal class SaleItemConfiguration : BaseEntityConfiguration<SaleItem, Guid>
    {
        public override void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("SaleItems");

            builder.Property(si => si.NameSnapshot)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(si => si.ManufacturingCompanySnapshot)
                .HasMaxLength(100);
            builder.Property(si => si.Quantity)
                .IsRequired();
            builder.Property(si => si.UnitPrice)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.Property(si => si.LineTotal)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.Property(si => si.IsMixed)
                .IsRequired();
            builder.Property(si => si.PerfumeOilGrams)
                .HasPrecision(10, 2);

            builder.HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(si => si.Bottle)
                .WithMany(b => b.SaleItems)
                .HasForeignKey(si => si.BottleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(si => si.PerfumeOil)
                .WithMany()
                .HasForeignKey(si => si.PerfumeOilId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(si => si.MixedPerfume)
                .WithOne(mp => mp.SaleItem)
                .HasForeignKey<MixedPerfume>(mp => mp.SaleItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
