using CodeWithMena.PerfumeShop.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Entities
{
    public class BasePerfumePrice : IBasePerfumePrice
    {
        public decimal? SupplierPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public virtual decimal? GetProfitMargin()
        {
            if (SupplierPrice == null || SalePrice == null) return null;
            return SalePrice.Value - SupplierPrice.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BasePerfumePrice)obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SupplierPrice);
        }
        public static bool operator ==(BasePerfumePrice? lPrice, BasePerfumePrice? rPrice)
            => (lPrice?.SalePrice == rPrice?.SalePrice) && (lPrice?.SupplierPrice == rPrice?.SupplierPrice);
        public static bool operator !=(BasePerfumePrice? lPrice, BasePerfumePrice? rPrice)
                  => !(lPrice == rPrice);

        public override string ToString()
        {
            return $"Supplier Price = {SupplierPrice}, Sale Price = {SalePrice}, The Profited is {GetProfitMargin()}";
        }
    }
}
