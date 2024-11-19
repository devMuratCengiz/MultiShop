using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutFooter:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _UILayoutFooter(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutsAsync();
            return View(values);
        }
    }
}
