using Microsoft.AspNetCore.Mvc;
using OrdersService.BLL;
using OrdersService.Mappers;
using OrdersService.Models;
using OrdersService.Models.DTO;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrdersBLL _ordersBLL;

        public OrdersController(IOrdersBLL ordersBLL)
        {
            _ordersBLL = ordersBLL;
        }

        [HttpPost]
        public async Task<Order> CreateNewOrderAsync(PostOrderDTO orderDTO)
        {
            return await _ordersBLL.CreateOrder(PostOrderDTOToOrderMapper.MapPostOrderDTOToOrder(orderDTO));
        }

        [HttpPut("{id}")]
        public async Task<Order> UpdateOrder(Guid id, PutOrderDTO order)
        {
            return await _ordersBLL.UpdateOrder(PutOrdetDTOToOrderMapper.MapPutOrderDTOToOrder(order, id));
        }

        [HttpGet("{id}")]
        public async Task<Object> GetOrder(Guid id)
        {
            var order = await _ordersBLL.GetOrder(id);

            if (order == null)
                return NotFound();

            return order;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (await _ordersBLL.DeleteOrder(id))
                return Ok(200);

            return NotFound();
        }
    }
}
