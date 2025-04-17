using Microsoft.EntityFrameworkCore;
using Nora.Orders.Domain.Contracts.Repositories;

namespace Nora.Orders.Infrastructure.Database.EntityFramework.Repositories;

public class AbstractRepository<TEntity, TKey> : IAbstractRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
    protected readonly DbSet<TEntity> DbSet;
    protected readonly DbContext DbContext;

    protected AbstractRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey id) => await DbSet.FindAsync(id);

    public virtual async Task AddAsync(TEntity entity) => await DbSet.AddAsync(entity);   

}