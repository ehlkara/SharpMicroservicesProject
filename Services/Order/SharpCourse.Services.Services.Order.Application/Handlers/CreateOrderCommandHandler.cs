using MediatR;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Order.Domain.OrderAggregate;
using SharpCourse.Services.Order.Infrastructure;
using SharpCourse.Services.Services.Order.Application.Commands;
using SharpCourse.Services.Services.Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCourse.Services.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.AddressDto.Province, request.AddressDto.District, 
                request.AddressDto.Street, request.AddressDto.ZipCode, request.AddressDto.Line);

            SharpCourse.Services.Order.Domain.OrderAggregate.Order newOrder = new SharpCourse.Services.Order.Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
