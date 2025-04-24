using Nora.Core.Domain.Entities;

namespace Nora.Orders.Domain.Entities;

public class OrderItem : Entity<int>
{
    public int ProductId { get; private set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; private set; }

    private OrderItem() { }

    public OrderItem(int productId)
    {
        ProductId = productId;
    }
}