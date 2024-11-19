using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ServiceDtos;
using MultiShop.WebUI.Services.CatalogServices.ServiceServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeature:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _DefaultFeature(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceService.GetAllServicesAsync();
            return View(values);
        }
    }
}
