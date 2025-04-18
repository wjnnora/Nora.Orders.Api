using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Configurations;
using Nora.Core.Database.Postgres.EntityFramework.Configurations;
using Nora.Orders.Api.Extensions;
using Nora.Orders.Api.Middlewares;
using Nora.Orders.Domain.Command.Commands.v1.Orders.Create;
using Nora.Orders.Domain.Query.Queries.v1.Orders.GetById;
using Nora.Orders.Infrastructure.Database.EntityFramework;
using Nora.Orders.Infrastructure.Database.EntityFramework.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR<CreateOrderCommandHandler, GetOrderByIdQueryHandler>();
builder.Services.AddEntityFramework<AppDbContext>(builder.Configuration);
builder.Services.AddRepositories<OrderRepository>();

var app = builder.Build();

if (builder.Configuration.GetSection("ExecuteMigration").Get<bool>())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
