using System;
using Sharp.Shared.Dtos;
using Sharp.Shared.Services;
using SharpCourse.Web.Models.FakePayments;
using SharpCourse.Web.Models.Orders;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPaymentService _paymentService;
        private readonly HttpClient _httpClient;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderService(IPaymentService paymentService, HttpClient httpClient, IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _paymentService = paymentService;
            _httpClient = httpClient;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.Get();

            var paymentInfoInput = new PaymentInfoInput()
            {
                CardName = checkoutInfoInput.CardName,
                CardNumber = checkoutInfoInput.CardNumber,
                Expiration = checkoutInfoInput.Expiration,
                CVV = checkoutInfoInput.CVV,
                TotalPrice = basket.TotalPrice
            };

            var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

            if (!responsePayment)
            {
                return new OrderCreatedViewModel() { Error = "It doesn't get payemnt.", IsSuccessful = false };
            }

            var orderCreateInput = new OrderCreateInput()
            {
                BuyerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput()
                {
                    Province = checkoutInfoInput.Province,
                    District = checkoutInfoInput.District,
                    Street = checkoutInfoInput.Street,
                    Line = checkoutInfoInput.Line,
                    ZipCode = checkoutInfoInput.ZipCode
                }
            };
            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemViewModel { ProductId = x.CourseId, ProductName = x.CourseName, Price = x.GetCurrentPrice, PictureUrl = ""};
                orderCreateInput.OrderItems.Add(orderItem);
            });

            var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders", orderCreateInput);

            if(!response.IsSuccessStatusCode)
            {
                return new OrderCreatedViewModel() { Error = "Order doesn't created", IsSuccessful = false };
            }

            var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();

            orderCreatedViewModel.Data.IsSuccessful = true;

            await _basketService.Delete();

            return orderCreatedViewModel.Data;
        }

        public async Task<List<OrderViewModel>> GetOrders()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");

            return response.Data;
        }

        public async Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.Get();

            var orderCreateInput = new OrderCreateInput()
            {
                BuyerId = _sharedIdentityService.GetUserId,
                Address = new AddressCreateInput()
                {
                    Province = checkoutInfoInput.Province,
                    District = checkoutInfoInput.District,
                    Street = checkoutInfoInput.Street,
                    Line = checkoutInfoInput.Line,
                    ZipCode = checkoutInfoInput.ZipCode
                }
            };
            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemViewModel { ProductId = x.CourseId, ProductName = x.CourseName, Price = x.GetCurrentPrice, PictureUrl = "" };
                orderCreateInput.OrderItems.Add(orderItem);
            });

            var paymentInfoInput = new PaymentInfoInput()
            {
                CardName = checkoutInfoInput.CardName,
                CardNumber = checkoutInfoInput.CardNumber,
                Expiration = checkoutInfoInput.Expiration,
                CVV = checkoutInfoInput.CVV,
                TotalPrice = basket.TotalPrice,
                Order = orderCreateInput
            };

            var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

            if (!responsePayment)
            {
                return new OrderSuspendViewModel() { Error = "It doesn't get payemnt.", IsSuccessful = false };
            }

            await _basketService.Delete();

            return new OrderSuspendViewModel() { IsSuccessful = true };
        }
    }
}

