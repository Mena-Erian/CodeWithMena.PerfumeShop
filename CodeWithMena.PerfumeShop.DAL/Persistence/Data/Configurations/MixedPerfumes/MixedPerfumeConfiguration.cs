using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.MixedPerfumes
{
    internal class MixedPerfumeConfiguration : BaseEntityConfiguration<MixedPerfume, Guid>
    {
        public override void Configure(EntityTypeBuilder<MixedPerfume> builder)
        {
            base.Configure(builder);

            builder.ToTable("MixedPerfumes");

            builder.Property(mp => mp.MixCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasIndex(mp => mp.SaleItemId).IsUnique();
            builder.HasIndex(mp => mp.MixCode).IsUnique();

            builder.HasMany(mp => mp.MixedPerfumeItems)
                .WithOne(mpi => mpi.MixedPerfume)
                .HasForeignKey(mpi => mpi.MixedPerfumeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
