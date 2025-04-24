using Nora.Core.Api.Refit.Extensions;
using Nora.Orders.Domain.Clients.v1.Product.Product;
using Nora.Orders.Domain.Clients.v1.User.User;

namespace Nora.Orders.Api.Extensions;

public static class RefitExtensions
{
    public static IServiceCollection AddRefitClients(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddUserClients(configuration)
            .AddProductClients(configuration);

        return services;
    }

    public static IServiceCollection AddUserClients(this IServiceCollection services, IConfiguration configuration)
    {
        var user = configuration.GetSection("ServiceEndpoints").GetValue<string>("User");        

        services
            .AddRefitClient<IUserClient>(user + "/v1/users");

        return services;
    }

    public static IServiceCollection AddProductClients(this IServiceCollection services, IConfiguration configuration)
    {
        var product = configuration.GetSection("ServiceEndpoints").GetValue<string>("Product");

        services
            .AddRefitClient<IProductClient>(product + "/v1/products");

        return services;
    }
}