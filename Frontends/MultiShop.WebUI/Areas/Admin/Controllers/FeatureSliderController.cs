using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
                return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
                return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index");
        }
    }
}
