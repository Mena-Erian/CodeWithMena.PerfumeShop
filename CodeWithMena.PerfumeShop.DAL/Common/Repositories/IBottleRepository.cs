using CodeWithMena.PerfumeShop.DAL.Common.Repositories.Base;
using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface IBottleRepository : IBaseRepository<Bottle, Guid>
    {
        Task<ICollection<Bottle>> GetActiveBottlesAsync();
    }
}
