﻿using MediatR;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Services.Order.Application.Dtos;

namespace SharpCourse.Services.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public AddressDto AddressDto { get; set; }
    }
}