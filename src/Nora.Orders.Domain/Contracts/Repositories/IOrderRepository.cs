using Nora.Core.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Contracts.Repositories;

public interface IOrderRepository : IRepository<Order, int>;