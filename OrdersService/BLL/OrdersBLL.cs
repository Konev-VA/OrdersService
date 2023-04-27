using OrdersService.DAL;
using OrdersService.Models;

namespace OrdersService.BLL
{
    public class OrdersBLL : IOrdersBLL
    {
        private IOrdersDAL _ordersDAL;

        public OrdersBLL(IOrdersDAL ordersDAL)
        {
            _ordersDAL = ordersDAL;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            //order.Status = StatusType.New;
            //order.Created = DateTime.Now;

            return await _ordersDAL.CreateOrder(order);
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = await _ordersDAL.GetOrder(id);

            if (order.StatusType == StatusType.InDelivery || order.StatusType == StatusType.Delivered || order.StatusType == StatusType.Completed)
                throw new Exception("Заказы со статусами \"передан в доставку\", \"доставлен\", \"завершен\" нельзя удалить");

            order.IsDeleted = true;

            await _ordersDAL.UpdateOrder(order);
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _ordersDAL.GetOrder(id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            if (await _ordersDAL.GetOrder(order.Id) == null)
                throw new Exception("Попытка обновления несуществующего заказа");


            if (order.StatusType == StatusType.Paid || order.StatusType == StatusType.InDelivery || order.StatusType == StatusType.Delivered || order.StatusType == StatusType.Completed)
                throw new Exception("Заказы со статусами \"оплачен\", \"передан в доставку\", \"доставлен\", \"завершен\" нельзя редактировать");

            await _ordersDAL.UpdateOrder(order);

            return await _ordersDAL.GetOrder(order.Id);
        }
    }
}
