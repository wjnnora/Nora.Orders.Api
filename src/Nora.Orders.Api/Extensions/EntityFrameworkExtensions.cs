using Microsoft.EntityFrameworkCore;
using Nora.Orders.Domain.Contracts.Contexts;
using Nora.Orders.Domain.Contracts.UnitOfWork;
using Nora.Orders.Infrastructure.Database.EntityFramework;

namespace Nora.Orders.Api.Extensions;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection AddEntityFramework<TDbContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TDbContext : DbContext
    {
        services
            .AddDbContext<TDbContext>(configuration)
            .AddScoped<ISqlContext, SqlContext>(provider => new SqlContext(provider.GetRequiredService<TDbContext>()))
            .AddScoped<IUnitOfWork<ISqlContext>, UnitOfWork<ISqlContext>>();

        return services;
    }

    private static IServiceCollection AddDbContext<TDbContext>(
        this IServiceCollection services,
        IConfiguration configuration) where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection") ?? string.Empty)
                .EnableSensitiveDataLogging();
        });

        return services;
    }
}