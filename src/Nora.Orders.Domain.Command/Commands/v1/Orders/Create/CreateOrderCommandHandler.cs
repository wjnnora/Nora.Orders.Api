using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Orders.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork<ISqlContext> unitOfWork) : IRequestHandler<CreateOrderCommand, Unit>
{
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.Customer);

        await orderRepository.AddAsync(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}