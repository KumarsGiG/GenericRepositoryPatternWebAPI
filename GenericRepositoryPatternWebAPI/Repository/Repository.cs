using GenericRepositoryPatternWebAPI.DatabaseContext;
using GenericRepositoryPatternWebAPI.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternWebAPI.Repository
{
    public class Repository<T>(AdventureWorks2019DatabaseContext _databaseContext) : IRepository<T> where T : class
    {
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _databaseContext.Set<T>().Add(entity);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _databaseContext.Set<T>().Remove(entity);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _databaseContext.Set<T>().FindAsync(id, cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
            => await _databaseContext.Set<T>().AsNoTracking().ToListAsync<T>(cancellationToken);

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _databaseContext.Set<T>().Update(entity);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}
