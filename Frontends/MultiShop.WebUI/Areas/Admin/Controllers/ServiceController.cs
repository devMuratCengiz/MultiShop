using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CatalogDtos.ServiceDtos;
using MultiShop.WebUI.Services.CatalogServices.ServiceServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceService.GetAllServicesAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            await _serviceService.CreateServiceAsync(createServiceDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {
            var value = await _serviceService.GetByIdServiceAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            await _serviceService.UpdateServiceAsync(updateServiceDto);
            return RedirectToAction("Index");
        }
    }
}
