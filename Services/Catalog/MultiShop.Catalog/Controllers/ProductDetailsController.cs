using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _productDetailService = ProductDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var value = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Deleted");
        }
    }
}
