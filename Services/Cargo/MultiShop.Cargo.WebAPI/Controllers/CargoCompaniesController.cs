using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DTO.Dtos.CargoCompanyDto;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult Create(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Added");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Deleted");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Updated");
        }
    }
}
