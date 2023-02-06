﻿using System;
using Sharp.Shared.Dtos;

namespace SharpCourse.Services.Discount.Services
{
	public interface IDiscountService
	{
		Task<Response<List<Models.Discount>>> GetAll();
		Task<Response<Models.Discount>> GetById();
		Task<Response<NoContent>> Save(Models.Discount discount);
		Task<Response<NoContent>> Update(Models.Discount discount);
		Task<Response<NoContent>> Delete(int id);
		Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId);
	}
}

