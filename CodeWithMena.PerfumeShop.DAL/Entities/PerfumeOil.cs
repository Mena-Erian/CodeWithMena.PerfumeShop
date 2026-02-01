using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Entities
{
    public class PerfumeOil : BasePerfume<PerfumeOil, Guid>
    {
        public string? SupplierName { get; set; }
        public ManufacturingCompany? ManufacturingCompany { get; set; }
        public string? AlternativeName { get; set; }
        public string? Code { get; set; }
        public string? FashionHouse { get; set; }
        public decimal? AvailableQuantityPerGram { get; set; }
    }
}