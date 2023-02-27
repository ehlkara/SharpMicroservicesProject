using System;
using SharpCourse.Web.Models.Discounts;

namespace SharpCourse.Web.Services.Interfaces
{
	public interface IDiscountService
	{
		Task<DiscountViewModel> GetDiscount(string discountCode);
	}
}

