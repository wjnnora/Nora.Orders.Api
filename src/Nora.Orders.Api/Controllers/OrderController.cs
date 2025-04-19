using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nora.Orders.Domain.Command.Commands.v1.Orders.Create;
using Nora.Orders.Domain.Query.Queries.v1.Orders.GetById;

namespace Nora.Orders.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]
public sealed class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand command)
    {
        await mediator.Send(command);        

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await mediator.Send(new GetOrderByIdQuery(id));

        return Ok(response);
    }


}