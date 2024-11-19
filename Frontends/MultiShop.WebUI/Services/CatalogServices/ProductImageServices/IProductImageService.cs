using MultiShop.Dto.CatalogDtos.ProductImagesDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    }
}
