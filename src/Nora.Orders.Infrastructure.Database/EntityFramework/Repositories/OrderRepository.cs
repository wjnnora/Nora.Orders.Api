using Nora.Core.Database.Postgres.EntityFramework;
using Nora.Orders.Domain.Contracts.Repositories;
using Nora.Orders.Domain.Entities;
namespace Nora.Orders.Infrastructure.Database.EntityFramework.Repositories;

public sealed class OrderRepository(AppDbContext context) : AbstractRepository<Order, int>(context), IOrderRepository;