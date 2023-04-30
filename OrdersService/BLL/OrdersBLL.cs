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
            if (order.Lines == null || order.Lines.Count == 0)
                throw new Exception("Невозможно создать заказ без строк");

            order.Lines.ForEach(x =>
            {
                if (x.Quantity <= 0)
                    throw new Exception("Кол-во товаров должно быть неотрицательным числом");
            });

            return await _ordersDAL.CreateOrder(order);
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await _ordersDAL.GetOrder(id);

            if (order == null || order.IsDeleted)
                return false;

            if (order.StatusType == StatusType.InDelivery || order.StatusType == StatusType.Delivered || order.StatusType == StatusType.Completed)
                throw new Exception("Заказы со статусами \"передан в доставку\", \"доставлен\", \"завершен\" нельзя удалить");

            order.IsDeleted = true;

            return await _ordersDAL.UpdateOrder(order) != null;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var order = await _ordersDAL.GetOrder(id);

            if (order == null || order.IsDeleted)
                return null;

            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var oldOrder = await _ordersDAL.GetOrder(order.Id);

            if (oldOrder == null || oldOrder.IsDeleted)
                throw new Exception("Попытка обновления несуществующего заказа");

            bool linesAreEquals = order.Lines.Count == oldOrder.Lines.Count;

            if (linesAreEquals)
                order.Lines.ForEach(x =>
                {
                    int curIndex = order.Lines.IndexOf(x);
                    if (x.ProductId != oldOrder.Lines[curIndex].ProductId || x.Quantity != oldOrder.Lines[curIndex].Quantity)
                        linesAreEquals = false;
                });


            if (!linesAreEquals && (oldOrder.StatusType == StatusType.Paid || oldOrder.StatusType == StatusType.InDelivery || oldOrder.StatusType == StatusType.Delivered || oldOrder.StatusType == StatusType.Completed))
                throw new Exception("Заказы со статусами \"оплачен\", \"передан в доставку\", \"доставлен\", \"завершен\" нельзя редактировать");

            await _ordersDAL.UpdateOrder(order);

            return await _ordersDAL.GetOrder(order.Id);
        }
    }
}
