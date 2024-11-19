using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _AboutService.GetAllAboutsAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _AboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _AboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {
            var value = await _AboutService.GetByIdAboutAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _AboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
    }

}
