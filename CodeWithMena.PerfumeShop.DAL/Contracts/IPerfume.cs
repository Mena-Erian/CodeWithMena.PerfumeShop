using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Contracts
{
    public interface IPerfume
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public FragranceType FragranceType { get; set; }
        public FragrancyFamily? FragrancyFamily { get; set; }
    }
}
