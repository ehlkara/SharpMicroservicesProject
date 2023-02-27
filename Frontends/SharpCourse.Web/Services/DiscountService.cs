using System;
using SharpCourse.Web.Models.Discounts;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
	public class DiscountService : IDiscountService
	{
		public DiscountService()
		{
		}

        public Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }
    }
}

