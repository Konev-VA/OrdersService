using BLLInterfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Models.Mappers;
using OrdersService.Mappers;

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
        public async Task<Object> CreateNewOrderAsync(PostOrderDTO orderDTO)
        {
            return HandleResult(await _ordersBLL.CreateOrder(PostOrderDTOToOrderMapper.MapPostOrderDTOToOrder(orderDTO)));
        }

        [HttpPut("{id}")]
        public async Task<Object> UpdateOrder(Guid id, PutOrderDTO order)
        {
            return HandleResult(await _ordersBLL.UpdateOrder(PutOrdetDTOToOrderMapper.MapPutOrderDTOToOrder(order, id)));
        }

        [HttpGet("{id}")]
        public async Task<Object> GetOrder(Guid id)
        {
            return HandleResult(await _ordersBLL.GetOrder(id));
        }

        [HttpDelete("{id}")]
        public async Task<Object> DeleteOrder(Guid id)
        {
            var result = HandleResult(await _ordersBLL.DeleteOrder(id));

            return result.StatusCode == 200 ? StatusCode(200) : result;
        }

        private ObjectResult HandleResult(ServiceResult<Order> result)
        {
            if (result.Success)
                return StatusCode(200, result.Value);

            if (result.IsException)
                // Здесь должно быть логирование непредвиденной ошибки

                // Также, учитывая, что не стоит лишний раз показывать наружу ошибку,
                // а также, что в рамках тестового задания неизвестно кто будет являться клиентом API,
                // возвращается просто "текст-заглушка".
                return StatusCode(409, "Что-то пошло не так");

            return StatusCode(409, result.FailureMessage);
        }
    }
}
