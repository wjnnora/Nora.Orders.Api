using MediatR;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Query.Queries.v1.Orders.GetById;

public sealed class GetOrderByIdQuery(int id) : IRequest<Order>
{
    public int Id { get; set; } = id;
}