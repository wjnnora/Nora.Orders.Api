using Refit;

namespace Nora.Orders.Domain.Clients.v1.User.User;

public interface IUserClient
{
    [Get("/{id}")]
    Task<UserResponse> GetByIdAsync(int id);
}