using Refit;

namespace Nora.Orders.Domain.Clients.v1.Product.Product;

public interface IProductClient
{
    [Get("/{id}")]
    Task<ProductResponse> GetByIdAsync(int id);
}