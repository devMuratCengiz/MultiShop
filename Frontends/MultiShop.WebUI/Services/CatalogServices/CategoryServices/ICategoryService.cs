using MultiShop.Dto.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCatgoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCatgoryDto);
        Task DeleteCategoryAsync(string id);
        Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
    }
}
