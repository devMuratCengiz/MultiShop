﻿using MultiShop.Dto.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
