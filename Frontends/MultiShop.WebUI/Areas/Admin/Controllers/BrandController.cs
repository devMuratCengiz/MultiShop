using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {
            var value = await _brandService.GetByIdBrandAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index");
        }
    }
 
}
