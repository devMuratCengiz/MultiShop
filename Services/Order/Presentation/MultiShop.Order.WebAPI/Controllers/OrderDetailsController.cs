using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetByIdOrderDetailQueryHandler _getByIdOrderDetailQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetByIdOrderDetailQueryHandler getByIdOrderDetailQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getByIdOrderDetailQueryHandler = getByIdOrderDetailQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetById(int id)
        {
            var value = await _getByIdOrderDetailQueryHandler.Handle( new GetByIdOrderDetailQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle( command );
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle( command );
            return Ok("Updated");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _removeOrderDetailCommandHandler.Handle( new RemoveOrderDetailCommand(id) );
            return Ok("Removed");
        }
    }
}
