using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Model;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceAsync orderServiceAsync;

        public OrdersController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Get()
        {
            var orders = await orderServiceAsync.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await orderServiceAsync.GetByIdAsync(id);
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
            var order = await orderServiceAsync.GetByCustomerIdAsync(customerId);
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
        public async Task<IActionResult> Save(OrderRequestModel order)
        {
            var result = await orderServiceAsync.InsertAsync(order);
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
        public async Task<IActionResult> Update(int id, [FromBody] OrderRequestModel order)
        {
            var result = await orderServiceAsync.UpdateAsync(order);
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
            var result = await orderServiceAsync.DeleteAsync(id);
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
