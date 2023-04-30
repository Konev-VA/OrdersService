using OrdersService.Models;

namespace OrdersService.BLL
{
    public interface IOrdersBLL
    {
        Task<Order> CreateOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order> GetOrder(Guid id);

        Task<bool> DeleteOrder(Guid id);
    }
}
