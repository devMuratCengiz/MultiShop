﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReview:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReview(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.pid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Comments/CommentListByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
