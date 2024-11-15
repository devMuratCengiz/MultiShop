using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ServiceDtos;
using MultiShop.Catalog.Services.ServiceServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServicesController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _ServiceService.GetAllServicesAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _ServiceService.GetByIdServiceAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            await _ServiceService.CreateServiceAsync(createServiceDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            await _ServiceService.UpdateServiceAsync(updateServiceDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ServiceService.DeleteServiceAsync(id);
            return Ok("Deleted");
        }
    }
}
