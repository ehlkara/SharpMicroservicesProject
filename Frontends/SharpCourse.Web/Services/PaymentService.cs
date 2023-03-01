using System;
using SharpCourse.Web.Models.FakePayments;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
    public class PaymentService : IPaymentService
    {


        public Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            throw new NotImplementedException();
        }
    }
}

