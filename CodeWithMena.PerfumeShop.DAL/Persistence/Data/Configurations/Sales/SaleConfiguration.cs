using CodeWithMena.PerfumeShop.DAL.Entities;
using CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Configurations.Sales
{
    internal class SaleConfiguration : BaseEntityConfiguration<Sale, Guid>
    {
        public override void Configure(EntityTypeBuilder<Sale> builder)
        {
            base.Configure(builder);

            builder.ToTable("Sales");

            builder.Property(s => s.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(s => s.SaleDateTime)
                .IsRequired();
            builder.Property(s => s.Subtotal)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.Property(s => s.DiscountPercent)
                .HasPrecision(5, 2);
            builder.Property(s => s.DiscountAmount)
                .HasPrecision(10, 2);
            builder.Property(s => s.TotalAfterDiscount)
                .HasPrecision(10, 2)
                .IsRequired();
            builder.Property(s => s.PaymentMethod)
                .HasMaxLength(50);
            builder.Property(s => s.Notes)
                .HasMaxLength(500);

            builder.HasIndex(s => s.InvoiceNumber).IsUnique();
            builder.HasIndex(s => s.SaleDateTime);

            builder.HasMany(s => s.SaleItems)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
