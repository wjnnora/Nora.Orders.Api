using Nora.Core.Domain.Entities;
using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Entities;

public class Order : Entity<int>
{    
    public Customer Customer { get; private set; }
    public virtual IEnumerable<OrderItem> OrderItems { get; private set; }

    private Order() { }

    public Order(Customer customer)
    {
        Customer = customer;
    }
}