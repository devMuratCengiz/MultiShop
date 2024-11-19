using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutNavbar:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UILayoutNavbar(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
