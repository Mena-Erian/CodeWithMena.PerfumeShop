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
    }
}
