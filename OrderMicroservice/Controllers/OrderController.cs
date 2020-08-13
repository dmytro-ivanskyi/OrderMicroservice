using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Service.RequestModels;
using Service.ServiceInterfaces;

namespace OrderMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        // private readonly ILogger<OrderController> _logger;

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _service.GetOrdersAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int orderId)
        {
            var result = await _service.GetOrderByIdAsync(orderId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrder createOrder)
        {
            var result = await _service.CreateOrderAsync(createOrder);

            if (result == null)
                return BadRequest();

            return Created( $"/api/{result.Id}", result);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int orderId, [FromBody] UpdateOrder updateOrder)
        {
            var result = await _service.UpdateOrderAsync(orderId, updateOrder);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int orderid)
        {
            var deleted = await _service.DeleteOrderAsync(orderid);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
