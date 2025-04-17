namespace Nora.Orders.Domain.Entities;

public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
}