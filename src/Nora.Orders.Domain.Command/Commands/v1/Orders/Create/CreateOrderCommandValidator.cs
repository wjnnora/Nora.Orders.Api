using FluentValidation;

namespace Nora.Orders.Domain.Command.Commands.v1.Orders.Create;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>   
{
    public CreateOrderCommandValidator()
    {
        RuleFor(r => r.UserId)
            .GreaterThan(0);
    }
}