using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Models.Order;

public sealed class CreateOrderRequest
{
    public Customer Customer { get; set; }
}