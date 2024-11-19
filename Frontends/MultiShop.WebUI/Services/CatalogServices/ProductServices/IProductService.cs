using MultiShop.Dto.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<ResultProductDto> GetByIdProductAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<List<ResultProductsWithCategoriesDto>> GetProductsWithCategoriesAsync();
        Task<List<ResultProductsWithCategoriesDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
