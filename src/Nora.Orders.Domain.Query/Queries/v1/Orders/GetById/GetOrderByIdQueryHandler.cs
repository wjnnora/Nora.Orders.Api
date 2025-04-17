using MediatR;
using Nora.Orders.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Query.Queries.v1.Orders.GetById;

public sealed class GetOrderByIdQueryHandler(
    IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, Order>
{
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        => await orderRepository.GetByIdAsync(request.Id);
}