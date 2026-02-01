using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.DailySummaries
{
    internal class DailySummaryConfiguration : BaseEntityConfiguration<DailySummary, Guid>
    {
        public override void Configure(EntityTypeBuilder<DailySummary> builder)
        {
            base.Configure(builder);

            builder.ToTable("DailySummaries");

            builder.Property(ds => ds.Date)
                .IsRequired();
            builder.Property(ds => ds.TotalSales)
                .HasPrecision(12, 2);
            builder.Property(ds => ds.TotalDiscount)
                .HasPrecision(12, 2);
            builder.Property(ds => ds.NetIncome)
                .HasPrecision(12, 2);
            builder.Property(ds => ds.InvoiceCount)
                .IsRequired();

            builder.HasIndex(ds => ds.Date).IsUnique();
        }
    }
}
