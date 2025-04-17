namespace Nora.Orders.Domain.Contracts.Repositories;

public interface IAbstractRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
    Task AddAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(TKey id);
}