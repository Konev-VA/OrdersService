using BLLInterfaces;
using Exceptions;
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
            try
            {
                return StatusCode(200, await _ordersBLL.CreateOrder(PostOrderDTOToOrderMapper.MapPostOrderDTOToOrder(orderDTO)));
            }
            catch (Exception ex) when (ex is MissingLinesException || ex is IncorrectLinesQuantityException)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                // Здесь должно быть логирование непредвиденной ошибки

                // Также, учитывая, что не стоит лишний раз показывать наружу ошибку,
                // а также, что в рамках тестового задания неизвестно кто будет являться клиентом API,
                // возвращается просто "текст-заглушка".
                return StatusCode(500, "Что-то пошло не так");
            }
        }

        [HttpPut("{id}")]
        public async Task<ObjectResult> UpdateOrder(Guid id, PutOrderDTO order)
        {
            try
            {
                return StatusCode(200, await _ordersBLL.UpdateOrder(PutOrdetDTOToOrderMapper.MapPutOrderDTOToOrder(order, id)));
            }
            catch (OrderNotFoundException ex)
            {
                return StatusCode(409, ex.Message);
            }
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
        public async Task<Object> DeleteOrder(Guid id)
        {
            //return BadRequest("Test error");

            //return new HttpResponseMessage() {StatusCode = System.Net.HttpStatusCode.BadRequest, Content = new StringContent("Test Error") };

            if (await _ordersBLL.DeleteOrder(id))
                return Ok();

            return NotFound();
        }
    }
}
