using MediatR;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommand : IRequest<Unit>
{
    public int UserId { get; set; }    
}