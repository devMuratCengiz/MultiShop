using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescription:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescription(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult>InvokeAsync(string id)
        {
            var value = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(value);
        }
    }
}
