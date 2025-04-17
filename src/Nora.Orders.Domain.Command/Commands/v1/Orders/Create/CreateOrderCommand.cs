using MediatR;
using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommand : IRequest<Unit>
{
    public Customer Customer { get; set; }
}