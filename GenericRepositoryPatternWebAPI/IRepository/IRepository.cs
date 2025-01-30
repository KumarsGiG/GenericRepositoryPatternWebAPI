namespace GenericRepositoryPatternWebAPI.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
