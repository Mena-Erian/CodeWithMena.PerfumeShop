using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWithMena.PerfumeShop.DAL.Contracts
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
