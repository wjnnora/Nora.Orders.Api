using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Contracts.Repositories;

public interface IOrderRepository : IAbstractRepository<Order, int>;