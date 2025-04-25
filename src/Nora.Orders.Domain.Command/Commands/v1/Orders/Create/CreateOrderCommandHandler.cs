using AutoMapper;
using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Core.Domain.Exceptions;
using Nora.Orders.Domain.Clients.v1.Product.Product;
using Nora.Orders.Domain.Clients.v1.User.User;
using Nora.Orders.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;
using Nora.Orders.Domain.Extensions;
using Nora.Orders.Domain.ValueObjects;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IUserClient userClient,
    IProductClient productClient,
    IMapper mapper) : IRequestHandler<CreateOrderCommand, Unit>
{
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(request);

        var user = await userClient.GetByIdAsync(request.UserId);

        var order = new Order(new Customer(user.Id, user.FullName));
        order = mapper.Map(request, order);

        await orderRepository.AddAsync(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }

    private async Task ValidateAsync(CreateOrderCommand request)
    {
        _ = await userClient.GetByIdAsync(request.UserId)
            ?? throw new DomainException($"User with id {request.UserId} not found.");

        await request.ProductIds.ForEachAsync(async (productId, ct) =>
        {
            await TryGetProductByIdAsync(productId);
        });        
    }

    private async Task<ProductResponse> TryGetProductByIdAsync(int productId)
    {
        try
        {
            return await productClient.GetByIdAsync(productId);
        }
        catch
        {
            throw new DomainException($"Product with id {productId} not found.");
        }
    }
}