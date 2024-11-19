using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductImagesDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSlider:ViewComponent
    {
        private readonly IProductImageService _productImageService;
public _ProductDetailImageSlider(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value =  await _productImageService.GetByProductIdProductImageAsync(id);
            return View(value);
        }
    }
}
