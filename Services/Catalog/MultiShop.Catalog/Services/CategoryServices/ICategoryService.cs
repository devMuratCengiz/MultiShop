using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCatgoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCatgoryDto);
        Task DeleteCategoryAsync(string id);
        Task <GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
