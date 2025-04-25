using Nora.Core.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Nora.Orders.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (DomainException ex)
        {
            var message = JsonSerializer.Serialize(new[] { ex.Message });
            await HandleRequestExceptionAsync(httpContext, message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            var message = JsonSerializer.Serialize(new[] { ex.Message });
            await HandleRequestExceptionAsync(httpContext, message, HttpStatusCode.InternalServerError);
        }
    }

    private static async Task HandleRequestExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(message);
    }
}