using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.MixedPerfumeItems
{
    internal class MixedPerfumeItemConfiguration : BaseEntityConfiguration<MixedPerfumeItem, Guid>
    {
        public override void Configure(EntityTypeBuilder<MixedPerfumeItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("MixedPerfumeItems");

            builder.Property(mpi => mpi.MlUsed)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.HasOne(mpi => mpi.MixedPerfume)
                .WithMany(mp => mp.MixedPerfumeItems)
                .HasForeignKey(mpi => mpi.MixedPerfumeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mpi => mpi.PerfumeOil)
                .WithMany()
                .HasForeignKey(mpi => mpi.PerfumeOilId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
