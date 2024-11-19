using MultiShop.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task<ResultProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultProductDto>();
            return values;
        }

        public async Task<List<ResultProductsWithCategoriesDto>> GetProductsWithCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoriesDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductsWithCategoriesDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategoryByCategoryId/" + categoryId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoriesDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
        }
    }
}
