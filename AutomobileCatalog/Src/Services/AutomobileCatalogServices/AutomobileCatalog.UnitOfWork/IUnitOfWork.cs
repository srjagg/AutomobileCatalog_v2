using AutomobileCatalog.Repositories.RepositoryInterface;

namespace AutomobileCatalog.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICarsRepository CarsRepository { get; }
        IBrandsRepository BrandsRepository { get; }
    }
}
