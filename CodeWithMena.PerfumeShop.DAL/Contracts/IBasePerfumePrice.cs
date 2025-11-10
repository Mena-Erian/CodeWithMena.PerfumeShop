using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Contracts
{
    public interface IBasePerfumePrice
    {
        public decimal? SupplierPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? GetProfitMargin();

    }
}
