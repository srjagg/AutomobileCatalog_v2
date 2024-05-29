using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryInterface;

namespace AutomobileCatalog.Repositories.RepositoryImplement
{
    public class CarsRepository : Repository<Cars>, ICarsRepository
    {
        public CarsRepository(AutomobileCatalogDbContext dbcontext) : base(dbcontext) { }

        public async Task<int> AddCarAsync(Cars car)
        {
            if (_context.Cars is not null)
            {
                await InsertAsync(car);
                return 0;
            }
            return 1;
        }

        public async Task<Cars?> GetCarByIdAsync(int id)
        {
            var car = await GetByIDAsync(id);

            if (car is null)
                return null;

            return car;
        }
    }
}
