using AutoMapper;
using Nora.Orders.Domain.Command.Commands.v1.Orders.Create;
using Nora.Orders.Domain.Entities;

namespace Nora.Orders.Domain.Command.Mappers;

public sealed class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderCommand, Order>()
            .ForMember(dest => dest.Customer, opt => opt.Ignore())
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.ProductIds.Select(productId => new OrderItem(productId))));
    }
}