﻿using MultiShop.Dto.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode/{code}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7178/api/Discounts/GetDiscountCouponRate?code=" + code);
            var valuse = await responseMessage.Content.ReadFromJsonAsync<int>();
            return valuse;
        }
    }
}
