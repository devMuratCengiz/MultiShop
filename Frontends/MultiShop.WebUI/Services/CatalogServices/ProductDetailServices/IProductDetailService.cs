using MultiShop.Dto.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}
