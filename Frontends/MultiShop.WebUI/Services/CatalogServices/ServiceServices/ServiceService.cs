using MultiShop.Dto.CatalogDtos.ServiceDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceServices
{
    public class ServiceService:IServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateServiceDto>("services", createServiceDto);

        }

        public async Task DeleteServiceAsync(string id)
        {
            await _httpClient.DeleteAsync("services/" + id);
        }


        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("services");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            return values;
        }

        public async Task<UpdateServiceDto> GetByIdServiceAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("services/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateServiceDto>();
            return values;
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateServiceDto>("services", updateServiceDto);
        }
    }
}
