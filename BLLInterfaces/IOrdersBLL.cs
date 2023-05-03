using Models;

namespace BLLInterfaces
{
    public interface IOrdersBLL
    {
        Task<Order> CreateOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order> GetOrder(Guid id);

        Task<bool> DeleteOrder(Guid id);
    }
}
