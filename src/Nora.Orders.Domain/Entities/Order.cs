using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Entities;

public class Order : BaseEntity<int>
{    
    public Customer Customer { get; private set; }

    private Order() { }

    public Order(Customer customer)
    {
        Customer = customer;
    }
}