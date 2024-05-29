using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryInterface;

namespace AutomobileCatalog.Repositories.RepositoryImplement
{
    public class BrandsRepository : Repository<Brands>, IBrandsRepository
    {
        public BrandsRepository(AutomobileCatalogDbContext dbcontext) : base(dbcontext) { }

        public async Task<int> AddBrandAsync(Brands brand)
        {
            if (_context.Brands is not null)
            {
                await InsertAsync(brand);
                return 0;
            }
            return 1;
        }

        public async Task<Brands?> GetBrandByIdAsync(int id)
        {
            var brand = await GetByIDAsync(id);

            if (brand is null)
                return null;

            return brand;
        }
    }
}
