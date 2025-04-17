using Microsoft.EntityFrameworkCore;
using Nora.Orders.Domain.Contracts.Contexts;
using Nora.Orders.Domain.Delegates;

namespace Nora.Orders.Infrastructure.Database.EntityFramework;

public class SqlContext(DbContext dbContext) : ISqlContext
{
    protected readonly DbContext DbContext = dbContext;

    public virtual async Task BeginTransactionAsync(TransactionDelegate codeBlock)
    {
        await using var transaction = await DbContext.Database.BeginTransactionAsync();

        try
        {
            await codeBlock();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();

            throw;
        }
    }

    public virtual async Task SaveChangesAsync()
        => await DbContext.SaveChangesAsync();
}
