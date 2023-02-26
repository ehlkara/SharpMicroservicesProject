﻿using System;
using SharpCourse.Web.Models.Baskets;
using SharpCourse.Web.Services.Interfaces;

namespace SharpCourse.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddBasketItem(BasketItemViewModel basketItemViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApplyDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelApplyDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<BasketViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveBasketItem(string courseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveOrUpdate(BasketViewModel basketViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

