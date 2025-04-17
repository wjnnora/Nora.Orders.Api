using Nora.Orders.Domain.Delegates;

namespace Nora.Orders.Domain.Contracts.Contexts;

public interface IContext
{
    Task BeginTransactionAsync(TransactionDelegate codeBlock);

    Task SaveChangesAsync();
}