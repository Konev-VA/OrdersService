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
        public async Task<Order> CreateNewOrderAsync(PostOrderDTO order)
        {
            return await _ordersBLL.CreateOrder(PostOrderDTOToOrderMapper.MapPostOrderDTOToOrder(order));
        }

        [HttpPut("{id}")]
        public async Task<Order> UpdateOrder(Guid id, PutOrderDTO order)
        {
            return await _ordersBLL.UpdateOrder(PutOrdetDTOToOrderMapper.MapPutOrderDTOToOrder(order, id));
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrder(Guid id)
        {
            return await _ordersBLL.GetOrder(id);
        }
    }
}
