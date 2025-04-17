using Nora.Orders.Domain.Contracts.Contexts;
using Nora.Orders.Domain.Delegates;

namespace Nora.Orders.Domain.Contracts.UnitOfWork;

public class UnitOfWork<TContext>(TContext dataBase) : IUnitOfWork<TContext> where TContext : IContext
{
    private readonly TContext _dataBase = dataBase;

    public virtual Task BeginTransactionAsync(TransactionDelegate codeBlock)
        => _dataBase.BeginTransactionAsync(codeBlock);

    public virtual Task SaveChangesAsync()
        => _dataBase.SaveChangesAsync();
}