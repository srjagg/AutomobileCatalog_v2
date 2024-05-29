using AutomobileCatalog.Models.Models;

namespace AutomobileCatalog.Repositories.RepositoryInterface
{
    public interface ICarsRepository
    {
        Task<int> AddCarAsync(Cars car);
        Task<Cars?> GetCarByIdAsync(int id);
    }
}
