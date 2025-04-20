using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Core.Domain.Exceptions;
using Nora.Orders.Domain.Clients.v1.User.User;
using Nora.Orders.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;
using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IUserClient userClient) : IRequestHandler<CreateOrderCommand, Unit>
{
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await userClient.GetByIdAsync(request.UserId)
            ?? throw new DomainException($"User with id {request.UserId} does not exists");

        var order = new Order(new Customer(user.Id, user.FullName));

        await orderRepository.AddAsync(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}