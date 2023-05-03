using BLLInterfaces;
using DALInterfaces;
using Exceptions;
using Models;

namespace BLLImplementations
{
    public class OrdersBLL : IOrdersBLL
    {
        private IOrdersDAL _ordersDAL;

        public OrdersBLL(IOrdersDAL ordersDAL)
        {
            _ordersDAL = ordersDAL;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            var order = await _ordersDAL.GetOrder(id);

            if (order == null || order.IsDeleted)
                throw new OrderNotFoundException("Такой заказ не существует"); ;

            return order;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            if (order.Lines == null || order.Lines.Count == 0)
                throw new MissingLinesException("Невозможно создать заказ без строк");

            if (order.Lines.Exists(x => x.Quantity <= 0))
                throw new IncorrectLinesQuantityException("Кол-во товаров должно быть неотрицательным числом");

            return await _ordersDAL.CreateOrder(order);
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await GetOrder(id);

            if (order.StatusType == StatusType.InDelivery || order.StatusType == StatusType.Delivered || order.StatusType == StatusType.Completed)
                throw new Exception("Заказы со статусами \"передан в доставку\", \"доставлен\", \"завершен\" нельзя удалить");

            order.IsDeleted = true;

            return await _ordersDAL.UpdateOrder(order) != null;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var oldOrder = await GetOrder(order.Id);

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

            // Повторный запрос в базу сделан для того, чтобы клиент увидел действительные изменения, внесённые в запись
            return await GetOrder(order.Id);
        }
    }
}
