using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeature:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailFeature(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            return View(value);
        }
    }
}
