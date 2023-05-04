using BLLInterfaces;
using DALInterfaces;
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

        public async Task<ServiceResult<Order>> GetOrder(Guid id)
        {
            try
            {
                var order = await _ordersDAL.GetOrder(id);

                if (order == null || order.IsDeleted)
                    return ServiceResult<Order>.FailureResult("Такой заказ не существует");

                return ServiceResult<Order>.SuccesResult(order);
            }
            catch (Exception ex)
            {
                return ServiceResult<Order>.ExceptionResult(ex);
            }
        }

        public async Task<ServiceResult<Order>> CreateOrder(Order order)
        {
            try
            {
                var linesValidationResult = ValidateLines(order);

                var linesAreCorrect = linesValidationResult.Success;

                if (!linesAreCorrect)
                {
                    return linesValidationResult;
                }

                return ServiceResult<Order>.SuccesResult(await _ordersDAL.CreateOrder(order));
            }
            catch (Exception ex)
            {
                return ServiceResult<Order>.ExceptionResult(ex);
            }
        }

        public async Task<ServiceResult<Order>> DeleteOrder(Guid id)
        {
            try
            {
                var serviceResult = await GetOrder(id);

                if (!serviceResult.Success)
                    return serviceResult;

                var order = serviceResult.Value;

                if (order.StatusType == StatusType.InDelivery || order.StatusType == StatusType.Delivered || order.StatusType == StatusType.Completed)
                    return ServiceResult<Order>.FailureResult("Заказы со статусами \"передан в доставку\", \"доставлен\", \"завершен\" нельзя удалить");

                order.IsDeleted = true;

                return ServiceResult<Order>.SuccesResult(await _ordersDAL.UpdateOrder(order));
            }
            catch (Exception ex)
            {
                return ServiceResult<Order>.ExceptionResult(ex);
            }
        }

        public async Task<ServiceResult<Order>> UpdateOrder(Order order)
        {
            try
            {
                var linesValidationResult = ValidateLines(order);

                var linesAreCorrect = linesValidationResult.Success;

                if (!linesAreCorrect)
                {
                    return linesValidationResult;
                }

                var serviceResult = await GetOrder(order.Id);

                if (!serviceResult.Success)
                    return serviceResult;

                var oldOrder = serviceResult.Value;

                bool linesAreEquals = order.Lines.Count == oldOrder.Lines.Count;

                if (linesAreEquals)
                    order.Lines.ForEach(x =>
                    {
                        int curIndex = order.Lines.IndexOf(x);
                        if (x.ProductId != oldOrder.Lines[curIndex].ProductId || x.Quantity != oldOrder.Lines[curIndex].Quantity)
                            linesAreEquals = false;
                    });


                if (!linesAreEquals && (oldOrder.StatusType == StatusType.Paid || oldOrder.StatusType == StatusType.InDelivery || oldOrder.StatusType == StatusType.Delivered || oldOrder.StatusType == StatusType.Completed))
                    return ServiceResult<Order>.FailureResult("Заказы со статусами \"оплачен\", \"передан в доставку\", \"доставлен\", \"завершен\" нельзя редактировать");

                await _ordersDAL.UpdateOrder(order);

                // Повторный запрос в базу сделан для того, чтобы клиент увидел действительные изменения, внесённые в запись
                return ServiceResult<Order>.SuccesResult((await GetOrder(order.Id)).Value);
            }
            catch (Exception ex)
            {
                return ServiceResult<Order>.ExceptionResult(ex);
            }
        }

        private ServiceResult<Order> ValidateLines(Order order)
        {
            if (order.Lines == null || order.Lines.Count == 0)
                return ServiceResult<Order>.FailureResult("Невозможно создать заказ без строк");

            if (order.Lines.Exists(x => x.Quantity <= 0))
                return ServiceResult<Order>.FailureResult("Кол-во товаров должно быть неотрицательным числом");

            return ServiceResult<Order>.SuccesResult(order);
        }
    }
}
