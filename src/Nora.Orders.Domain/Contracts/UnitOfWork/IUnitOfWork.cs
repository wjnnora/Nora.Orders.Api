using Nora.Orders.Domain.Contracts.Contexts;
using Nora.Orders.Domain.Delegates;

namespace Nora.Orders.Domain.Contracts.UnitOfWork;

public interface IUnitOfWork<TContext> where TContext : IContext
{
    Task BeginTransactionAsync(TransactionDelegate codeBlock);

    Task SaveChangesAsync();
}