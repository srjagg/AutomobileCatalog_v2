using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryImplement;
using AutomobileCatalog.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomobileCatalog.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutomobileCatalogDbContext _context;
        public UnitOfWork(IConfiguration configuration, DbContextOptions<AutomobileCatalogDbContext> options) 
        {
            _context = new AutomobileCatalogDbContext(configuration, options);
            CarsRepository = new CarsRepository(_context);
            BrandsRepository = new BrandsRepository(_context);
        }

        public ICarsRepository CarsRepository { get; }
        public IBrandsRepository BrandsRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
