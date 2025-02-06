using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return Ok("No order found");
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpGet]
        [Route("Customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var order = await _orderRepository.GetByCustomerIdAsync(customerId);
            if (order == null)
            {
                return Ok("No order found");
            }
            else
            {
                return Ok(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(Orders order)
        {
            var result = await _orderRepository.InsertAsync(order);
            if (result == 1)
            {
                return Ok("New order is saved");
            }
            else 
            {
                return BadRequest("Error!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Orders order)
        {
            var result = await _orderRepository.UpdateAsync(order);
            if (result == 1)
            {
                return Ok("Order is updated");
            }
            else
            {
                return BadRequest("Error!");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderRepository.DeleteAsync(id);
            if (result == 1)
            {
                return Ok("Delete successfully");
            }
            else if (result == 0)
            {
                return Ok("Not Exist");
            }
            else
            { 
                return BadRequest("Error");
            }
        }
    }
}
