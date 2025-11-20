using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Entities
{
    public abstract class BasePerfume<TPerfume, TKey> : BaseEntity<TKey>, IPerfume
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public FragranceType FragranceType { get; set; }
        public FragranceFamily? FragranceFamily { get; set; }
        public int RatingOfSale { get; set; }
        public BasePerfumePrice? PerfumePrice { get; set; }
    }
}
