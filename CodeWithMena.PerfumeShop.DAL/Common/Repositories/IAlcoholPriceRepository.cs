using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface IAlcoholPriceRepository
    {
        Task<AlcoholPrice?> GetLatestAsync();
        Task<AlcoholPrice?> GetByIdAsync(Guid id);
        Task<int> AddAsync(AlcoholPrice entity);
        Task<int> UpdateAsync(AlcoholPrice entity);
    }
}
