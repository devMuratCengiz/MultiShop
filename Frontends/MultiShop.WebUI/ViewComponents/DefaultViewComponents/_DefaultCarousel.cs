using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCarousel:ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _DefaultCarousel(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(values);
        }
    }
}
