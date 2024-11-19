using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategory:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
