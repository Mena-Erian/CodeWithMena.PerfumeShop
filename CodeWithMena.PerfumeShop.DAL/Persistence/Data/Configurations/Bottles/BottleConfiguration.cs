using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Bottles
{
    internal class BottleConfiguration : BaseEntityConfiguration<Bottle, Guid>
    {
        public override void Configure(EntityTypeBuilder<Bottle> builder)
        {
            base.Configure(builder);

            builder.ToTable("Bottles");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.SizeMl)
                .IsRequired();
            builder.Property(b => b.SalePrice)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(b => b.Name).IsUnique();
            builder.HasMany(b => b.SaleItems)
                .WithOne(si => si.Bottle)
                .HasForeignKey(si => si.BottleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
