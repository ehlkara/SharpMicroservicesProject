using System;
using SharpCourse.Web.Models.Orders;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IOrderService
	{
		/// <summary>
		/// Sync communication- direct request to microservice
		/// </summary>
		/// <param name="checkoutInfoInput"></param>
		/// <returns></returns>
		Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);


		/// <summary>
		/// Async communication- Order ınfo sent to rabbitmq
		/// </summary>
		/// <param name="checkoutInfoInput"></param>
		/// <returns></returns>
		Task SuspendOrder(CheckoutInfoInput checkoutInfoInput);

		Task<List<OrderViewModel>> GetOrders();
	}
}

