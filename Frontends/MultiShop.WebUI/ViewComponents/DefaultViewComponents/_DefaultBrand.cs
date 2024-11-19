using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBrand:ViewComponent
    {
        private readonly IBrandService _brandService;

        public _DefaultBrand(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
    }
}
