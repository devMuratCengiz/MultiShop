using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _service.GetAllDiscountCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _service.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _service.CreateDiscountCouponAsync(createDiscountCouponDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _service.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok("Updated");
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            await _service.DeleteDiscountCouponAsync(id);
            return Ok("Deleted");
        }
    }
}
