using AutomobileCatalog.Models.Models;

namespace AutomobileCatalog.Repositories.RepositoryInterface
{
    public interface IBrandsRepository
    {
        Task<int> AddBrandAsync(Brands brand);
    }
}
