using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DTO.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult Create(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer customer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname
            };
            _cargoCustomerService.TInsert(customer);
            return Ok("Added");
        }
        [HttpPut]
        public IActionResult Update(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer customer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Address = updateCargoCustomerDto.Address,
                Email = updateCargoCustomerDto.Email,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname
            };
            _cargoCustomerService.TUpdate(customer);
            return Ok("Updated");
        }
    }
}
