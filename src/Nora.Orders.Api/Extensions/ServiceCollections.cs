using MediatR;
using Nora.Orders.Infrastructure.Database.EntityFramework.Repositories;

namespace Nora.Orders.Api.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<OrderRepository>()
            .AddClasses(classes => classes.Where(t => t.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddMediatR<T1>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1));
        return services;
    }

    public static IServiceCollection AddMediatR<T1, T2>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1), typeof(T2));        
        return services;
    }
}