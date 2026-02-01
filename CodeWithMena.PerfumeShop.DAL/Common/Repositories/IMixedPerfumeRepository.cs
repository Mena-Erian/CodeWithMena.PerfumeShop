using CodeWithMena.PerfumeShop.DAL.Entities;

namespace CodeWithMena.PerfumeShop.DAL.Common.Repositories
{
    public interface IMixedPerfumeRepository
    {
        Task<MixedPerfume?> GetByMixCodeWithDetailsAsync(string mixCode);
    }
}
