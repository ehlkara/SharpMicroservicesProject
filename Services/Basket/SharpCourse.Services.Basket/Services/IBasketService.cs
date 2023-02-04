using System;
using Sharp.Shared.Dtos;
using SharpCourse.Services.Basket.Dtos;

namespace SharpCourse.Services.Basket.Services
{
	public interface IBasketService
	{
		Task<Response<BasketDto>> GetBasket(string userId);

		Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

		Task<Response<bool>> Delete(string userId);
	}
}

