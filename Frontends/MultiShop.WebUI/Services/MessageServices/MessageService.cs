﻿using MultiShop.Dto.DiscountDtos;
using MultiShop.Dto.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/services/Message/UserMessages/GetMessageInbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/services/Message/UserMessages/GetMessageSendbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }
    }
}
