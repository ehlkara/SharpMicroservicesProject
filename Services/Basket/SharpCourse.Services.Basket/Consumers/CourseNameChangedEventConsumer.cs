using System;
using MassTransit;
using Sharp.Shared.Messages;
using SharpCourse.Services.Basket.Services;

namespace SharpCourse.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly IBasketService _basketService;

        public CourseNameChangedEventConsumer(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var basket = await _basketService.GetBasket(context.Message.UserId);

            var basketItems = basket.Data.basketItems.Where(x => x.CourseId == context.Message.CourseId).ToList();

            basketItems.ForEach(x =>
            {
                x.CourseName = context.Message.UpdatedName;
            });

            await _basketService.SaveOrUpdate(basket.Data);
        }
    }
}

