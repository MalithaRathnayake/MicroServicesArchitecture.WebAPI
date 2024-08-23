using KooBits.MicroServices.OrderServices.Interfaces;
using KooBits.MicroServices.OrderServices.Models;
using KooBits.MicroServices.OrderServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KooBits.MicroServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<IOrderService> _logger;

        public OrderController(IOrderService orderService, ILogger<IOrderService> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var users = await _orderService.GetOrdersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var user = await _orderService.GetOrderAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                await _orderService.AddOrderAsync(order);
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderID }, order);
            }            
            catch(InvalidOperationException ex)
            {
                _logger.LogError(ex, "Invalid User ID.");
                return StatusCode(401, "Invalid User ID.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving books.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
