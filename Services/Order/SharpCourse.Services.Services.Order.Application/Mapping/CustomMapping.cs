using AutoMapper;
using SharpCourse.Services.Order.Domain.OrderAggregate;
using SharpCourse.Services.Services.Order.Application.Dtos;

namespace SharpCourse.Services.Services.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<SharpCourse.Services.Order.Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
