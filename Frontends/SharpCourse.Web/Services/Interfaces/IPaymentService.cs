using System;
using SharpCourse.Web.Models.FakePayments;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IPaymentService
	{
		Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
	}
}

