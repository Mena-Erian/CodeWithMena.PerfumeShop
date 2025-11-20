using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Common.Enums
{
    [Flags]
    public enum FragranceType
    {
        Male = 1,
        Female = 2,
        // 3 is Male and Female
        East = 4, // 
        Other = 7
    }
}
