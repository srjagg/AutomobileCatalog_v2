
using AutomobileCatalog.Persistense;
using Microsoft.EntityFrameworkCore;

namespace AutomobileCatalog.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AutomobileCatalogDbContext _context;
        public Repository(AutomobileCatalogDbContext context)
        {
            _context = context;
        }

        public void ValidateEntity<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }
        public async Task AddAsync<TEntity>(TEntity entity)
        {
            ValidateEntity(entity);
            await _context.AddAsync(entity, default(CancellationToken));
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete<TEntry>(TEntry entity)
        {
            ValidateEntity(entity);

            _context.Entry(entity).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<int> InsertAsync(T entity)
        {
            await _context.AddAsync(entity, default(CancellationToken));
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void ModifiedState<TEntry>(TEntry entity)
        {
            ValidateEntity(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity)
        {
            if (entity == null)
                return false;

            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
